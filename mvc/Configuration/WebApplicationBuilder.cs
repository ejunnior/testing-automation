namespace FrontEnd.Configuration
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;

    public static class WebApplicationBuilder
    {
        public static IApplicationBuilder Configure(
            this IApplicationBuilder app,
            IWebHostEnvironment hostingEnvironment,
            Action<IEndpointRouteBuilder> endpointConfigurator = null)
        {
            return app
                //.UseAuthentication()
                .UseMiddleware<ExceptionHandler>()
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseCookiePolicy()
                .UseRouting()
                //.UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}