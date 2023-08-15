using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Lasmart.Domain;

namespace Lasmart.Persistence.EntityTypeConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(comment => comment.ID);
            builder.HasIndex(comment => comment.ID).IsUnique();
            builder.Property(comment => comment.ID).IsRequired();
            builder.Property(comment => comment.Text).IsRequired();
            builder.Property(comment => comment.BackgroundColor).IsRequired();
            builder.Property(comment => comment.PointID).IsRequired();  
        }
    }
}
