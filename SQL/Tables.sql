CREATE DATABASE CashTransferSystem;

CREATE TABLE CashTransferSystem.dbo.Transfers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    SenderFirstName NVARCHAR(100) NOT NULL,
	SenderLastName NVARCHAR(100) NOT NULL,
    SenderPesel NVARCHAR(11) NOT NULL,
    ReceiverAccountNumber NVARCHAR(26) NOT NULL,
    ReceiverName NVARCHAR(100) NOT NULL,
    ReceiverNip NVARCHAR(10) NOT NULL,
    ReceiverRegon NVARCHAR(9) NOT NULL,
    ReceiverAddress NVARCHAR(200) NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    TransferTypeId INT NOT NULL,
    SaveToAddressBook BIT NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);


ALTER TABLE dbo.Transfers
ADD CONSTRAINT FK_Transfers_TransferTypes
FOREIGN KEY (TransferTypeId) REFERENCES TransferTypes(Id);


CREATE TABLE CashTransferSystem.dbo.TransferTypes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL
);


CREATE TABLE CashTransferSystem.dbo.AddressBook (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Nip NVARCHAR(10) NOT NULL,
    Regon NVARCHAR(9) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    AccountNumber NVARCHAR(26) NOT NULL
);