using System;

namespace AuditApp
{
    public class AuditEvent
    {
        public long Id { get; set; }

        public string Application { get; set; }

        public string Tenant { get; set; }

        public string User { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime HappenedOn { get; set; }

        public string JSON { get; set; }
    }
}
