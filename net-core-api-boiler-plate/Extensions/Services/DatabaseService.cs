using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using net_core_api_boiler_plate.Database.DB;
using net_core_api_boiler_plate.Database.Repository.Implementation;
using net_core_api_boiler_plate.Database.Repository.Interface;

namespace net_core_api_boiler_plate.Extensions.Services
{
    public static class DatabaseService
    {
        public static void AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("AzureDB")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}