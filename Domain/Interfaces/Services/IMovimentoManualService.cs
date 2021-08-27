using Domain.Entities;
using Domain.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IMovimentoManualService : IServiceBase<MOVIMENTO_MANUAL>
    {
        Task<List<MOVIMENTO_MANUAL>> GetLancamento(string produtoId, string cosifId);
    }
}
