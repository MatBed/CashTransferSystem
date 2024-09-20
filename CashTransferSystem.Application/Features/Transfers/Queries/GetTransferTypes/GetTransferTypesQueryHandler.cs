using CashTransferSystem.Application.Mappers;
using CashTransferSystem.Core.Interfaces;
using MediatR;

namespace CashTransferSystem.Application.Features.Transfers.Queries.GetTransferTypes
{
    public class GetTransferTypesQueryHandler : IRequestHandler<GetTransferTypesQuery, List<GetTransferTypesResponse>>
    {
        private readonly ICashTransferRepository _cashTransferRepository;

        public GetTransferTypesQueryHandler(ICashTransferRepository cashTransferRepository)
        {
            _cashTransferRepository = cashTransferRepository;
        }

        public async Task<List<GetTransferTypesResponse>> Handle(GetTransferTypesQuery request, CancellationToken cancellationToken)
        {
            var transferTypes = await _cashTransferRepository.GetAllTransferTypesAsync();

            return TransferMapper.MapTransferTypeEntitiesToGetTransferTypesResponse(transferTypes).ToList();
        }
    }
}
