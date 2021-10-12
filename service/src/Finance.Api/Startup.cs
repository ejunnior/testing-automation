namespace Finance.Api
{
    using Finance.Api.Configuration;
    using Infrastructure.Data.UnitOfWork;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Configure(
                hostingEnvironment: env);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<FinanceUnitOfWork>(options =>
                {
                    options.UseSqlServer(Configuration["DatabaseConnectionString"]);
                })
                .AddDependencies()
                .RegisterSwagger()
                .AddCors()
                .AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = ModelStateValidator.ValidateModelState;
                });
        }
    }
}