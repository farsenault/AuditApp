using Microsoft.EntityFrameworkCore;

namespace AuditApp
{
    public class AuditContext : DbContext
    {
        public AuditContext(DbContextOptions<AuditContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<AuditEntity> AuditEntities { get; set; }               
    }
}
