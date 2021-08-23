using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();        
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
        
    }
}