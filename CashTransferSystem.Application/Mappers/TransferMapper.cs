using CashTransferSystem.Application.Features.Transfers.Commands.CreateTransfer;
using CashTransferSystem.Application.Features.Transfers.Queries.GetTransfers;
using CashTransferSystem.Application.Features.Transfers.Queries.GetTransferTypes;
using CashTransferSystem.Core.Entities;

namespace CashTransferSystem.Application.Mappers;

public static class TransferMapper
{
	public static IEnumerable<GetTransfersResponse> MapTransferEntitiesToGetTransfersResponse(IEnumerable<TransferEntity> transferEntities)
	{
		foreach (var entity in transferEntities)
		{
			yield return new GetTransfersResponse(entity.SenderFirstName, 
				entity.SenderLastName,
				entity.SenderPesel, 
				entity.ReceiverAccountNumber, 
				entity.ReceiverName, 
				entity.ReceiverNip, 
				entity.ReceiverRegon, 
				entity.ReceiverAddress, 
				entity.Amount, 
				entity.TransferType, 
				entity.Status);
		}
	}

    public static IEnumerable<GetTransferTypesResponse> MapTransferTypeEntitiesToGetTransferTypesResponse(IEnumerable<TransferTypeEntity> transferTypeEntities)
    {
        foreach (var entity in transferTypeEntities)
        {
            yield return new GetTransferTypesResponse(entity.Id, entity.Name);
        }
    }

    public static TransferEntity MapCreateTransferCommandToTransferEntity(CreateTransferCommand createTransferCommand) => 
		new TransferEntity
		{
			SenderFirstName = createTransferCommand.SenderFirstName,
			SenderLastName = createTransferCommand.SenderLastName,
			SenderPesel = createTransferCommand.SenderPesel,
			ReceiverAccountNumber = createTransferCommand.ReceiverAccountNumber,
			ReceiverName = createTransferCommand.ReceiverName,
			ReceiverNip = createTransferCommand.ReceiverNip,
			ReceiverRegon = createTransferCommand.ReceiverRegon,
			ReceiverAddress = createTransferCommand.ReceiverAddress,
			Amount = createTransferCommand.Amount,
			TransferTypeId = createTransferCommand.TransferTypeId,
			SaveToAddressBook = createTransferCommand.SaveToAddressBook
		};
}
