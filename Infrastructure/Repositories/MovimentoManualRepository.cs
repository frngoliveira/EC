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
        public async Task<List<MOVIMENTO_MANUAL>> GetLancamento()
        {
            using (var ctx = new Context(Db))
            {
                 return await (from m in ctx.MOVIMENTO_MANUAL                       
                       join c in ctx.PRODUTO_COSIF 
                            on m.COD_COSIF equals c.COD_COSIF
                            where(m.COD_COSIF == c.COD_COSIF)
                            select m
                    ).ToListAsync();
            }            
        }
    }
}
