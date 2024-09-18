
using CashTransferSystem.Application.Features.Transfers.Commands.CreateTransfer;
using CashTransferSystem.Application.Features.Transfers.Queries.GetTransfers;
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
            var tasks = await mediator.Send(new GetTransfersQuery());
            return Results.Ok(tasks);
        }
    }
}
