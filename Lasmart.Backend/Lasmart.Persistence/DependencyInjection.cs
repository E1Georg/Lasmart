using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lasmart.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Lasmart.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<LasmartDbContext>(options => {
                options.UseInMemoryDatabase(databaseName: connectionString); //connectionString = <<databaseName: "Name">>
            });

            services.AddScoped<ILasmartDbContext>(provider => provider.GetService<LasmartDbContext>());

            return services;
        }
    }
}
