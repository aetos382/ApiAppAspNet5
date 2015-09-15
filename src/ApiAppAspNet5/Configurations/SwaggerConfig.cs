namespace ApiAppAspNet5.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Framework.DependencyInjection;

    using Swashbuckle.Swagger;

    public static class SwaggerConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagger(
                config =>
                {
                    config.SwaggerGeneratorOptions.SingleApiVersion(
                        new Info
                        {
                            Version = "v1",
                            Title = "ApiAppAspNet5"
                        });

                    config.SwaggerGeneratorOptions.BasePath = "/";

                    config.SwaggerGeneratorOptions.Schemes = new[] { "https" };

                    config.SwaggerGeneratorOptions.OperationFilter<IncludeParameterNamesOperationFilter>();
                });
        }

        // Configure is called after ConfigureServices is called.
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger("swagger/{apiVersion}/swagger.json");
            app.UseSwaggerUi("swagger/ui");
        }
    }
}
