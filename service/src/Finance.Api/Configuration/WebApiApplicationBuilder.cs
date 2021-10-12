namespace Finance.Api.Configuration
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;

    public static class WebApiApplicationBuilder
    {
        public static IApplicationBuilder Configure(
            this IApplicationBuilder app,
            IWebHostEnvironment hostingEnvironment,
            Action<IEndpointRouteBuilder> endpointConfigurator = null)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finance.Api v1"));
            });

            app.UseMiddleware<ExceptionHandler>();

            app.UseAuthentication();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllers();
            });

            return app;
        }
    }
}