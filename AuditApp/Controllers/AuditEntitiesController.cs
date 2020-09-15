using JsonDiffPatchDotNet;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace AuditApp.Controllers
{
    [ApiController]
    [Route("api/auditentities")]
    public class AuditEntitiesController : ControllerBase
    {        
        private readonly AuditContext _context;

        public AuditEntitiesController(AuditContext context)
        {            
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AuditEntity> Get()
        {            
            return _context.AuditEntities.AsEnumerable();
        }

        [HttpPost]
        public void Post([FromBody] AuditEntity auditEntity)
        {
            var existingEntity = GetEntity(auditEntity.Application, auditEntity.EntityId, auditEntity.EntityType);

            if (!string.IsNullOrWhiteSpace(existingEntity))
            {
                CalculatePatch(existingEntity, auditEntity);                
            }

            _context.Add(auditEntity);
            _context.SaveChanges();
        }

        private void CalculatePatch(string originalEntity, AuditEntity auditEntity)
        {            
            var jdp = new JsonDiffPatch();

            foreach (var patch in GetPatches(auditEntity.Application, auditEntity.EntityId, auditEntity.EntityType))
                originalEntity = jdp.Patch(originalEntity, patch);
            
            var left = JToken.Parse(originalEntity);
            var right = JToken.Parse(auditEntity.Entity);
            var newPatch = jdp.Diff(left, right);

            auditEntity.Entity = null;
            auditEntity.Patch = newPatch.ToString(Formatting.None);
        }
        
        private string GetEntity(string application, string entityId, string entityType) =>        
            _context.AuditEntities.FirstOrDefault(e => e.Application ==  application
                                            && e.EntityId == entityId
                                            && e.EntityType == entityType
                                            && e.Entity != null)?.Entity;   
        
        private IEnumerable<string> GetPatches(string application, string entityId, string entityType) =>
            _context.AuditEntities
                        .Where(e => e.Application == application
                                    && e.EntityId == entityId
                                    && e.EntityType == entityType
                                    && e.Patch != null)
                        .OrderBy(e => e.HappenedOn)
                        .Select(t => t.Patch);
    }
}
