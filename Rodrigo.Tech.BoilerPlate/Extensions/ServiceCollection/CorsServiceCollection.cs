using Microsoft.Extensions.DependencyInjection;

namespace Rodrigo.Tech.BoilerPlate.Extensions.ServiceCollection
{
    public static class CorsServiceCollection
    {
        private static readonly string _defaultCorsPolicy = "DefaultCorsPolicy";

        /// <summary>
        ///     Adds CORS services
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsService(this IServiceCollection services)
        {
            services.AddCors(x => x.AddPolicy(_defaultCorsPolicy,
                options =>
                {
                    options.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                ;
                }));
        }
    }
}