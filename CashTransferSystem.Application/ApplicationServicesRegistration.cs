using CashTransferSystem.Application.Features.Transfers.Commands.CreateTransfer;
using CashTransferSystem.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CashTransferSystem.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CreateTransferCommandValidator>();

        services.AddInfrastructureServices();

        return services;
    }
}
