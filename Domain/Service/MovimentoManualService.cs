using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class MovimentoManualService : ServiceBase<MOVIMENTO_MANUAL>, IMovimentoManualService
    {
        private readonly IMovimentoManualRepository _movimentoManualRepository;
        public MovimentoManualService(IMovimentoManualRepository movimentoManualRepository) : base(movimentoManualRepository)
        {
            _movimentoManualRepository = movimentoManualRepository;
        }

        public async Task<object> GetLancamento()
        {
            return await _movimentoManualRepository.GetLancamento();
        }
    }

    
}
