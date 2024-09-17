using CashTransferSystem.Core.Entities;

namespace CashTransferSystem.Core.Interfaces;

public interface ICashTransferRepository
{
	Task<bool> CreateTransferAsync(TransferEntity transfer);

	Task<IEnumerable<TransferEntity>> GetAllTransfersAsync(); 
}
