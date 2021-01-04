using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Rodrigo.Tech.Model.Constants;
using System;

namespace Rodrigo.Tech.BoilerPlate.Extensions.ServiceCollection
{
    public static class AuthenticationServiceCollection
    {
        /// <summary>
        ///     Adds Authentication Service
        /// </summary>
        /// <param name="services"></param>
        public static void AddAuthenticationService(this IServiceCollection services)
        {
            var instance = Environment.GetEnvironmentVariable(EnvironmentConstants.INSTANCE);
            var tenantId = Environment.GetEnvironmentVariable(EnvironmentConstants.TENANT_ID);
            var clientId = Environment.GetEnvironmentVariable(EnvironmentConstants.CLIENT_ID);
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Audience = $"api://{clientId}";
                options.Authority = $"{instance}/{tenantId}";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true
                };
            });
        }
    }
}