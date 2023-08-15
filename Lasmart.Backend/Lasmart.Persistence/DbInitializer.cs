namespace Lasmart.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(LasmartDbContext context)
        {
            // context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
