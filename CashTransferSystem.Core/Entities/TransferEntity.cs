namespace CashTransferSystem.Core.Entities;

public class TransferEntity : BaseEntity
{
	public string SenderName { get; set; }

	public string SenderPesel { get; set; }

	public string ReceiverAccountNumber { get; set; }

	public string ReceiverName { get; set; }

	public string ReceiverNip { get; set; }

	public string ReceiverRegon { get; set; }

	public string ReceiverAddress { get; set; }

	public decimal Amount { get; set; }

	public int TransferTypeId { get; set; }

	public TransferTypeEntity TransferType { get; set; }

	public bool SaveToAddressBook { get; set; }

	public string Status { get; set; }
}