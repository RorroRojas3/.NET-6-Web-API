using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Rodrigo.Tech.Model.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Rodrigo.Tech.BoilerPlate.Extensions.ServiceCollection
{
    public static class SwashbuckleServiceCollection
    {
        /// <summary>
        ///     Service to add Swashbuckle (Swagger)
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwashbuckleService(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddApiVersioning();
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            var instance = Environment.GetEnvironmentVariable(EnvironmentConstants.INSTANCE);
            var tenantId = Environment.GetEnvironmentVariable(EnvironmentConstants.TENANT_ID);
            var tokenEndpoint = Environment.GetEnvironmentVariable(EnvironmentConstants.OAUTH2_TOKEN);
            var authorizeEndpoint = Environment.GetEnvironmentVariable(EnvironmentConstants.OAUTH2_AUTHORIZE);
            var scope = Environment.GetEnvironmentVariable(EnvironmentConstants.SCOPE);
            var clientID = Environment.GetEnvironmentVariable(EnvironmentConstants.CLIENT_ID);
            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition(SecuritySchemeType.OAuth2.ToString(), new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Description = "Azure ADD Authentication",
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            TokenUrl = new Uri($"{instance}/{tenantId}/{tokenEndpoint}"),
                            AuthorizationUrl = new Uri($"{instance}/{tenantId}/{authorizeEndpoint}"),
                            Scopes = { { string.Format(scope, clientID), "User access" } }
                        }
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);               
            });
        }
    }

    /// <summary>
    ///     ConfigureSwaggerOptions class
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        ///     ConfigureSwaggerOptions constructor with DI
        /// </summary>
        /// <param name="provider"></param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
          this.provider = provider;

        /// <summary>
        ///     Adds swagger documentation
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                  description.GroupName,
                    new OpenApiInfo()
                    {
                        Title = $".NET Core Boiler Plate",
                        Description = $".NET Core Boiler Plate Example",
                        Version = description.ApiVersion.ToString(),
                    });
            }
        }
    }
}