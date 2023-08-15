using Microsoft.EntityFrameworkCore;
using Lasmart.Domain;

namespace Lasmart.Application.Interfaces
{
    public interface ILasmartDbContext
    {
        DbSet<Point> Points { get; set; }
        DbSet<Comment> Comments { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
