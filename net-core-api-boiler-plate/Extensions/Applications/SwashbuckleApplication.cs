using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace net_core_api_boiler_plate.Extensions.Applications
{
    public static class SwashbuckleApplication
    {
        public static void AddSwashbuckleApp(this IApplicationBuilder application, IApiVersionDescriptionProvider provider)
        {
            application.UseSwagger();
            application.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }

                    options.RoutePrefix = string.Empty;
                });
        }
    }
}