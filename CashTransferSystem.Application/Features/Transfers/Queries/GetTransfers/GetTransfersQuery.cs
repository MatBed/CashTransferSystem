using MediatR;

namespace CashTransferSystem.Application.Features.Transfers.Queries.GetTransfers;

public record GetTransfersQuery : IRequest<List<GetTransfersResponse>>;
