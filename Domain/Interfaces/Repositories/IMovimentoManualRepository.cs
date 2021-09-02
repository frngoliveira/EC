using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IMovimentoManualRepository : IRepositoryBase<MOVIMENTO_MANUAL>
    {
        Task<List<MOVIMENTO_MANUAL>> GetLancamento();
    }
}
