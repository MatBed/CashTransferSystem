using CashTransferSystem.Application.Mappers;
using CashTransferSystem.Core.Interfaces;
using MediatR;

namespace CashTransferSystem.Application.Features.Transfers.Commands.CreateTransfer;

public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
{
	private readonly ICashTransferRepository _cashTransferRepository;

	public CreateTransferCommandHandler(ICashTransferRepository cashTransferRepository)
	{
		_cashTransferRepository = cashTransferRepository;
	}

	public async Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
	{
		return await _cashTransferRepository.CreateTransferAsync(TransferMapper.MapCreateTransferCommandToTransferEntity(request));
	}
}
