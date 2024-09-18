using CashTransferSystem.Core.Entities;
using CashTransferSystem.Core.Enums;
using CashTransferSystem.Core.Interfaces;
using CashTransferSystem.Infrastructure.Data;
using CashTransferSystem.Infrastructure.Static;
using Dapper;
using System.Data;

namespace CashTransferSystem.Infrastructure.Repositories
{
	public class CashTransferRepository : ICashTransferRepository
	{
		private readonly DatabaseContext _dbContext;

		public CashTransferRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> CreateTransferAsync(TransferEntity transfer)
		{
			using var connection = _dbContext.CreateConnection();

			var parameters = new
			{
				SenderFirstName = transfer.SenderFirstName,
				SenderLastName = transfer.SenderLastName,
				SenderPesel = transfer.SenderPesel,
				ReceiverAccountNumber = transfer.ReceiverAccountNumber,
				ReceiverName = transfer.ReceiverName,
				ReceiverNip = transfer.ReceiverNip,
				ReceiverRegon = transfer.ReceiverRegon,
				ReceiverAddress = transfer.ReceiverAddress,
				Amount = transfer.Amount,
				TransferTypeId = transfer.TransferTypeId,
				SaveToAddressBook = transfer.SaveToAddressBook,
				Status = DateTime.Now.Minute % 2 == 0 ? TransferStatus.Completed.ToString() : TransferStatus.Rejected.ToString(),
			};

			var result = await connection.ExecuteAsync(SqlQuery.CreateTransfer, parameters, commandType: CommandType.StoredProcedure);

			return result > 0;
		}

		public async Task<IEnumerable<TransferEntity>> GetAllTransfersAsync()
		{
			using var connection = _dbContext.CreateConnection();

			return await connection.QueryAsync<TransferEntity>(SqlQuery.GetAllTransfers);
		}
	}
}
