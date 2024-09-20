namespace CashTransferSystem.Infrastructure.Static;

public static class SqlQuery
{
	public static string GetAllTransfers = @"SELECT Id,
			SenderFirstName,
			SenderLastName,
			SenderPesel,
			ReceiverAccountNumber,
			ReceiverName,
			ReceiverNip,
			ReceiverRegon,
			ReceiverAddress,
			Amount,
			TransferType,
			SaveToAddressBook,
			Status,
			CreatedAt
		FROM [CashTransferSystem].[dbo].[vwTransfersWithDetails]";

	public static string CreateTransfer = "pCreateTransfer";

	public static string GetAllTransferTypes = "SELECT Id, Name FROM [CashTransferSystem].[dbo].[TransferTypes]";
}
