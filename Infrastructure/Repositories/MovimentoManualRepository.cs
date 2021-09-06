using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class MovimentoManualRepository : RepositoryBase<MOVIMENTO_MANUAL>, IMovimentoManualRepository
    {
        public async Task<object> GetLancamento()
        {
            using (var ctx = new Context(Db))
            {
                 return await (from m in ctx.MOVIMENTO_MANUAL
                       join c in ctx.PRODUTO_COSIF on m.COD_COSIF equals c.COD_COSIF
                       join p in ctx.PRODUTO on c.COD_PRODUTO equals p.COD_PRODUTO
                       select new
                       {
                           m.DAT_MES,
                           m.DAT_ANO,
                           m.DES_DESCRICAO,
                           m.NUM_LANCAMENTO,
                           m.VAL_VALOR,
                           p.DESC_PRODUTO,
                           p.COD_PRODUTO
                       }
                   ).OrderBy(mm => mm.NUM_LANCAMENTO).ToListAsync();
            }           
        }
    }
}
