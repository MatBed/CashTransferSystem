using MediatR;

namespace CashTransferSystem.Application.Features.Transfers.Queries.GetTransferTypes;

public record GetTransferTypesQuery : IRequest<List<GetTransferTypesResponse>>;
