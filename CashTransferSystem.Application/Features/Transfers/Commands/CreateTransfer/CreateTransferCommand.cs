using MediatR;

namespace CashTransferSystem.Application.Features.Transfers.Commands.CreateTransfer;

public record CreateTransferCommand(string SenderFirstName,
	string SenderLastName,
	string SenderPesel,
	string ReceiverAccountNumber,
	string ReceiverName,
	string ReceiverNip,
	string ReceiverRegon,
	string ReceiverAddress,
	decimal Amount,
	int TransferTypeId,
	bool SaveToAddressBook) : IRequest<bool>;