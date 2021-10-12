namespace Finance.Api.Configuration
{
    using System.Reflection;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Category.Aggregates.CategoryAggregate;
    using Domain.Core;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Domain.Treasury.Aggregates.PayableAggregate;
    using Infrastructure.Data.BankAccount.Repository;
    using Infrastructure.Data.Category.Repository;
    using Infrastructure.Data.Creditor.Repository;
    using Infrastructure.Data.Payable.Repository;
    using Infrastructure.Data.UnitOfWork;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddRepositories()
                .AddDispatcher()
                .AddUnitOfWork()
                .AddCommandHandlers()
                .AddQueryHandlers();
        }

        private static IServiceCollection AddDispatcher(this IServiceCollection services)
        {
            return services.AddSingleton<IDispatcher, Dispatcher>();
        }

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                var sources = scan.FromAssemblies(Assembly.Load("Finance.Application"));

                sources
                    .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime();
            });

            return services;
        }

        private static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                var sources = scan.FromAssemblies(Assembly.Load("Finance.Application"));

                sources
                    .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime();
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICreditorRepository, CreditorRepository>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<IPayableRepository, PayableRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IFinanceUnitOfWork, FinanceUnitOfWork>();
        }
    }
}