using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rodrigo.Tech.BoilerPlate.Database.DB;
using Rodrigo.Tech.BoilerPlate.Database.Repository.Implementation;
using Rodrigo.Tech.BoilerPlate.Database.Repository.Interface;

namespace Rodrigo.Tech.BoilerPlate.Extensions.Services
{
    public static class DatabaseService
    {
        /// <summary>
        ///     Adds database service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("AZURE_DB")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}