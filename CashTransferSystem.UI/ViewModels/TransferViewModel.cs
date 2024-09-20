namespace CashTransferSystem.UI.ViewModels;

public record TransferViewModel(string SenderFirstName,
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
