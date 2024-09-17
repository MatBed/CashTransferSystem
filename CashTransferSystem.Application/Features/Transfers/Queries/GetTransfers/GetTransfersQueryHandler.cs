using CashTransferSystem.Application.Mappers;
using CashTransferSystem.Core.Interfaces;
using MediatR;

namespace CashTransferSystem.Application.Features.Transfers.Queries.GetTransfers;

public class GetTransfersQueryHandler : IRequestHandler<GetTransfersQuery, List<GetTransfersResponse>>
{
	private readonly ICashTransferRepository _cashTransferRepository;

	public GetTransfersQueryHandler(ICashTransferRepository cashTransferRepository)
	{
		_cashTransferRepository = cashTransferRepository;
	}

	public async Task<List<GetTransfersResponse>> Handle(GetTransfersQuery request, CancellationToken cancellationToken)
	{
		var transfers = await _cashTransferRepository.GetAllTransfersAsync();

		return TransferMapper.MapTransferEntitiesToGetTransfersResponse(transfers).ToList();
	}
}
