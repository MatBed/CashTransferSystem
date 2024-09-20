using CashTransferSystem.Application.Features.Transfers.Queries.GetTransfers;
using CashTransferSystem.Application.Features.Transfers.Queries.GetTransferTypes;
using CashTransferSystem.Core.Interfaces;
using Moq;

namespace CashTransferSystem.Tests.CashTransfers;

[TestFixture]

public class QueriesTests
{
    private Mock<ICashTransferRepository> _mockTransferRepository;
    private GetTransfersQueryHandler _getTransfersQueryHandler;
    private GetTransferTypesQueryHandler _getTransferTypesQueryHandler;

    [SetUp]
    public void Setup()
    {
        _mockTransferRepository = new Mock<ICashTransferRepository>();
        _getTransfersQueryHandler = new GetTransfersQueryHandler(_mockTransferRepository.Object);
        _getTransferTypesQueryHandler = new GetTransferTypesQueryHandler(_mockTransferRepository.Object);
    }

    [Test]
    public async Task Handle_ShouldCallGetTransfers()
    {
        // Arrange
        var query = new GetTransfersQuery();

        // Act
        await _getTransfersQueryHandler.Handle(query, CancellationToken.None);

        // Assert
        _mockTransferRepository.Verify(r => r.GetAllTransfersAsync(), Times.Once);
    }

    [Test]
    public async Task Handle_ShouldCallGetTransferTypes()
    {
        // Arrange
        var query = new GetTransferTypesQuery();

        // Act
        await _getTransferTypesQueryHandler.Handle(query, CancellationToken.None);

        // Assert
        _mockTransferRepository.Verify(r => r.GetAllTransferTypesAsync(), Times.Once);
    }
}
