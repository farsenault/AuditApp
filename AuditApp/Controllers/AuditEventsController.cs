using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AuditApp.Controllers
{
    [ApiController]
    [Route("api/auditevents")]
    public class AuditEventsController : ControllerBase
    {        
        private readonly AuditContext _context;

        public AuditEventsController(AuditContext context)
        {            
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AuditEvent> Get()
        {            
            return _context.AuditEvents.AsEnumerable();
        }

        [HttpPost]
        public void Post([FromBody] AuditEvent auditEvent)
        {
            _context.Add(auditEvent);
            _context.SaveChanges();
        }        
    }
}
