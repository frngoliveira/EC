using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class MovimentoManualRepository : RepositoryBase<MOVIMENTO_MANUAL>, IMovimentoManualRepository
    {        
        public async Task<List<MOVIMENTO_MANUAL>> GetLancamento(string produtoId, string cosifId)
        {
            using (var ctx = new Context(Db))
            {
                return await ctx.MOVIMENTO_MANUAL
                    .Where(p => p.COD_PRODUTO == produtoId 
                                    && p.COD_COSIF == cosifId)
                    .Include("PRODUTO")
                    .Include("PRODUTO_COSIF").ToListAsync();
            };
        }
    }
}
