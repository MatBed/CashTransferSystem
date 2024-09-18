using CashTransferSystem.Core.Interfaces;
using CashTransferSystem.Infrastructure.Data;
using CashTransferSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashTransferSystem.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<DatabaseContext>();
        services.AddScoped<ICashTransferRepository, CashTransferRepository>();

        return services;
    }
}
