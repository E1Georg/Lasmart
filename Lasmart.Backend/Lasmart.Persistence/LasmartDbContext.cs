using Lasmart.Domain;
using Lasmart.Application.Interfaces;
using Lasmart.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Lasmart.Persistence
{
    public class LasmartDbContext : DbContext, ILasmartDbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public LasmartDbContext(DbContextOptions<LasmartDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PointConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.Entity<Comment>()
                .HasOne<Point>(x => x.Point)
                .WithMany(point => point.Comments)
                .HasForeignKey(o => o.PointID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
