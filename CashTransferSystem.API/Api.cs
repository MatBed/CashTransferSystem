using CashTransferSystem.Application.Features.Transfers.Commands.CreateTransfer;
using CashTransferSystem.Application.Features.Transfers.Queries.GetTransfers;
using CashTransferSystem.Application.Features.Transfers.Queries.GetTransferTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CashTransferSystem.API
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/transfers", GetCashTransfers).WithSummary("Endpoint for get collection with cash transfers");
            app.MapPost("/transfers", CreateCashTransfers).WithSummary("Endpoint for create cash transfer");
            app.MapGet("/transferTypes", GetTransferTypes).WithSummary("Endpoint for get transfer types");
        }

        private static async Task<IResult> GetTransferTypes([FromServices] IMediator mediator)
        {
            var transfers = await mediator.Send(new GetTransferTypesQuery());
            return Results.Ok(transfers);
        }

        private static async Task<IResult> CreateCashTransfers(
            [FromBody] CreateTransferCommand command,
            [FromServices] IMediator mediator)
        {
            var success = await mediator.Send(command);
            return Results.Ok(new { Success = success });
        }

        private static async Task<IResult> GetCashTransfers([FromServices] IMediator mediator)
        {
            var transfers = await mediator.Send(new GetTransfersQuery());
            return Results.Ok(transfers);
        }
    }
}
