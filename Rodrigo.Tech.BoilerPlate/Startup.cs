using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rodrigo.Tech.BoilerPlate.Database.DB;
using Rodrigo.Tech.BoilerPlate.Extensions.Applications;
using Rodrigo.Tech.BoilerPlate.Extensions.Services;
using Serilog;

namespace Rodrigo.Tech.BoilerPlate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        ///     Configure services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLoggingService(Configuration);
            Log.Information("Adding Controller and NewtonSoftJson Service");
            services.AddControllers().AddNewtonsoftJson();
            Log.Information("Adding Swashbuckle Service");
            services.AddSwashbuckleService();
            Log.Information("Adding Custom Service");
            services.AddCustomService();
            Log.Information("Adding Database Service");
            services.AddDatabaseService(Configuration);
            Log.Information("Adding AutoMapper service");
            services.AddAutoMapperService();
            Log.Information("Adding Cache Service");
            services.AddCacheService(Configuration);
            Log.Information("Adding Helper Service");
            services.AddHelpersService();
            Log.Information("Adding Data Protection Service");
            services.AddDataProtectionService();
            Log.Information("Adding Azure Cosmos DB");
            //services.AddAzureCosmosService(Configuration);
            Log.Information("Adding HttpContextAccesor Service");
            services.AddHttpContextAccessor();
        }

        /// <summary>
        ///     Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider"></param>
        /// <param name="db"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                                IApiVersionDescriptionProvider provider,
                                DatabaseContext db)
        {
            Log.Information($"Using Exception middleware");
            app.UseExceptionMiddleware();
            Log.Information($"Using HttpsRedirection");
            app.UseHttpsRedirection();
            Log.Information($"Using Routing");
            app.UseRouting();
            Log.Information($"Using Auhtorization");
            app.UseAuthorization();
            Log.Information($"Using Endpoint");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            Log.Information($"Using Swashbuckle");
            app.UseSwashbuckle(provider);

            Log.Information($"Using Migration of DB");
            db.Database.Migrate();
        }
    }
}
