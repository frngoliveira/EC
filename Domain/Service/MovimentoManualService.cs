using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Service
{
    public class MovimentoManualService : ServiceBase<MOVIMENTO_MANUAL>, IMovimentoManualService
    {
        private readonly IMovimentoManualRepository _movimentoManualRepository;
        public MovimentoManualService(IMovimentoManualRepository movimentoManualRepository) : base(movimentoManualRepository)
        {
            _movimentoManualRepository = movimentoManualRepository;
        }
    }

    
}
