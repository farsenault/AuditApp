using System;

namespace AuditApp
{
    public sealed class AuditEntity
    {
        public long Id { get; set; }

        public string Application { get; set; }

        public string Tenant { get; set; }

        public string User { get; set; }

        public string Action { get; set; }        

        public DateTime HappenedOn { get; set; }

        public string EntityId { get; set; }

        public string EntityType { get; set; }

        public string Entity { get; set; }

        public string Patch { get; set; }
    }
}
