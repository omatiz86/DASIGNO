using Microsoft.OpenApi.Models;

namespace PruebaDemokrata.Api.Extensions
{
    public static class SwaggerServicesExtensions
    {

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PruebaDemokrata",
                    Version = "v1",
                    Description = "MicroServicio"
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerGen(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "PruebaDemokrata v1"));
            return app;
        }


    }
}
