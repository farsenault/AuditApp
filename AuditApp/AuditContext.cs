using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditApp
{
    public class AuditContext : DbContext
    {
        public AuditContext(DbContextOptions<AuditContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<AuditEvent> AuditEvents { get; set; }               
    }
}
