CREATE VIEW dbo.vwTransfersWithDetails
AS
SELECT 
    t.Id,
    t.SenderFirstName,
	t.SenderLastName,
    t.SenderPesel,
    t.ReceiverAccountNumber,
    t.ReceiverName,
    t.ReceiverNip,
    t.ReceiverRegon,
    t.ReceiverAddress,
    t.Amount,
    tt.Name AS TransferType,
    t.SaveToAddressBook,
    t.Status,
    t.CreatedAt
FROM Transfers t
JOIN TransferTypes tt ON t.TransferTypeId = tt.Id;