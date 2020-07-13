using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Database.DB;
using net_core_api_boiler_plate.Extensions.Applications;
using net_core_api_boiler_plate.Extensions.Services;
using Serilog;

namespace net_core_api_boiler_plate
{
    /// <summary>
    ///     Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Startup constructor with DI
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///     Configuration settings
        /// </summary>
        /// <value></value>
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
            Log.Information("Adding TestController Service");
            services.AddTestControllerService();
            Log.Information("Adding Database Service");
            services.AddDatabaseService(Configuration);
            Log.Information("Adding AutoMapper service");
            services.AddAutoMapperService();
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
