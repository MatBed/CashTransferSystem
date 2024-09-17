namespace CashTransferSystem.Core.Entities;

public class AddressBookEntryEntity : BaseEntity
{
	public string ReceiverName { get; set; }

	public string ReceiverNip { get; set; }

	public string ReceiverRegon { get; set; }

	public string ReceiverAddress { get; set; }
}
