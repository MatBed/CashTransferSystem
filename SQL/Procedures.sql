CREATE PROCEDURE dbo.pCreateTransfer
    @SenderFirstName NVARCHAR(100),
	@SenderLastName NVARCHAR(100),
    @SenderPesel NVARCHAR(11),
    @ReceiverAccountNumber NVARCHAR(26),
    @ReceiverName NVARCHAR(100),
    @ReceiverNip NVARCHAR(10),
    @ReceiverRegon NVARCHAR(9),
    @ReceiverAddress NVARCHAR(200),
    @Amount DECIMAL(18, 2),
    @TransferTypeId INT,
    @SaveToAddressBook BIT,
    @Status NVARCHAR(64)
AS
BEGIN
    INSERT INTO dbo.Transfers (SenderFirstName, SenderLastName, SenderPesel, ReceiverAccountNumber, ReceiverName, ReceiverNip, ReceiverRegon, ReceiverAddress, Amount, TransferTypeId, SaveToAddressBook, Status)
    VALUES (@SenderFirstName, @SenderLastName, @SenderPesel, @ReceiverAccountNumber, @ReceiverName, @ReceiverNip, @ReceiverRegon, @ReceiverAddress, @Amount, @TransferTypeId, @SaveToAddressBook, @Status);
    
    IF @SaveToAddressBook = 1
    BEGIN
        IF NOT EXISTS (
            SELECT 1 FROM dbo.AddressBook
            WHERE Nip = @ReceiverNip AND AccountNumber = @ReceiverAccountNumber
        )
        BEGIN
            INSERT INTO dbo.AddressBook (Name, Nip, Regon, Address, AccountNumber)
            VALUES (@ReceiverName, @ReceiverNip, @ReceiverRegon, @ReceiverAddress, @ReceiverAccountNumber);
        END
    END
END;