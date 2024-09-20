using CashTransferSystem.Application.Features.Transfers.Commands.CreateTransfer;
using CashTransferSystem.Core.Entities;
using CashTransferSystem.Core.Interfaces;
using Moq;

namespace CashTransferSystem.Tests.CashTransfers;

[TestFixture]
public class CommandsTests
{
    private Mock<ICashTransferRepository> _mockTransferRepository;
    private CreateTransferCommandHandler _handler;

    [SetUp]
    public void Setup()
    {
        _mockTransferRepository = new Mock<ICashTransferRepository>();
        _handler = new CreateTransferCommandHandler(_mockTransferRepository.Object);
    }

    [Test]
    public async Task Handle_ShouldCallCreateTransfer_WhenCommandIsValid()
    {
        // Arrange
        var command = new CreateTransferCommand("aaa", "aaa", "12345678912", "12345678912123456789123456", "aaa", "1234567891", "123456789", "aaa", 123, 1, false);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _mockTransferRepository.Verify(r => r.CreateTransferAsync(It.IsAny<TransferEntity>()), Times.Once);
    }
}