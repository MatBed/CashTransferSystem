namespace CashTransferSystem.Core.Entities;

public class TransferEntity : BaseEntity
{
	public string SenderFirstName { get; set; }

	public string SenderLastName { get; set; }

	public string SenderPesel { get; set; }

	public string ReceiverAccountNumber { get; set; }

	public string ReceiverName { get; set; }

	public string ReceiverNip { get; set; }

	public string ReceiverRegon { get; set; }

	public string ReceiverAddress { get; set; }

	public decimal Amount { get; set; }

	public int TransferTypeId { get; set; }

	public string TransferType { get; set; }

	public bool SaveToAddressBook { get; set; }

	public string Status { get; set; }
}