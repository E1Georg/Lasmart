using Lasmart.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Lasmart.Persistence.EntityTypeConfigurations
{
    public class PointConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.HasKey(point => point.PointID);
            builder.HasIndex(point => point.PointID).IsUnique();
            builder.Property(point => point.PointID).IsRequired();
            builder.Property(point => point.x).IsRequired();
            builder.Property(point => point.y).IsRequired();
            builder.Property(point => point.Radius).IsRequired();
            builder.Property(point => point.Color).IsRequired();            
        }
    }
}
