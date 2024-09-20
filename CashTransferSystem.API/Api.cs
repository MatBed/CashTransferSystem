using CashTransferSystem.Application.Features.Transfers.Commands.CreateTransfer;
using CashTransferSystem.Application.Features.Transfers.Queries.GetTransfers;
using CashTransferSystem.Application.Features.Transfers.Queries.GetTransferTypes;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CashTransferSystem.API
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/transfers", GetCashTransfers).WithSummary("Endpoint for get collection with cash transfers");
            app.MapGet("/transferTypes", GetTransferTypes).WithSummary("Endpoint for get transfer types");
            app.MapPost("/transfers", CreateCashTransfers).WithSummary("Endpoint for create cash transfer");
        }

        private static async Task<IResult> GetCashTransfers([FromServices] IMediator mediator)
        {
            var transfers = await mediator.Send(new GetTransfersQuery());
            return Results.Ok(transfers);
        }

        private static async Task<IResult> GetTransferTypes([FromServices] IMediator mediator)
        {
            var transfers = await mediator.Send(new GetTransferTypesQuery());
            return Results.Ok(transfers);
        }

        private static async Task<IResult> CreateCashTransfers(
            IValidator<CreateTransferCommand> validator,
            [FromBody] CreateTransferCommand command,
            [FromServices] IMediator mediator)
        {
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var success = await mediator.Send(command);
            return Results.Ok(new { Success = success });
        }
    }
}
