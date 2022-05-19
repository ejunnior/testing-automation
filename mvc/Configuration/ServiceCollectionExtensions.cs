namespace FrontEnd.Configuration
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services
                .AddScoped<IFinanceHttpClient, FinanceHttpClient>();
            services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews();

            return services;
        }
    }
}