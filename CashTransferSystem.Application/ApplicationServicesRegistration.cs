using CashTransferSystem.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CashTransferSystem.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddInfrastructureServices();

        return services;
    }
}
