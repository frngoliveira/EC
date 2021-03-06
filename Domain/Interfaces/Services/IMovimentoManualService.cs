using Domain.Entities;
using Domain.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IMovimentoManualService : IServiceBase<MOVIMENTO_MANUAL>
    {
        Task<object> GetLancamento();
    }
}
