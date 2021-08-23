using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;



namespace Infrastructure.Repositories
{    
    public class ProdutoRepository : RepositoryBase<PRODUTO>, IProdutoRepository
    {        
    }
}
