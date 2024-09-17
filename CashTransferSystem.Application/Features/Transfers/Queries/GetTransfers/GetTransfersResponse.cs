namespace CashTransferSystem.Application.Features.Transfers.Queries.GetTransfers;

public record GetTransfersResponse(string SenderFirstName,
	string SenderLastName,
	string SenderPesel,
	string ReceiverAccountNumber,
	string ReceiverName,
	string ReceiverNip,
	string ReceiverRegon,
	string ReceiverAddress,
	decimal Amount,
	string TransferType,
	string Status);