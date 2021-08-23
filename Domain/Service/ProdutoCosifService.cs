using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Service
{
    public class ProdutoCosifService : ServiceBase<PRODUTO_COSIF>, IProdutoCosifService
    {
        private readonly IProdutoCosifRepository _produtoCosifRepository;
        public ProdutoCosifService(IProdutoCosifRepository produtoCosifRepository) : base(produtoCosifRepository)
        {
            _produtoCosifRepository = produtoCosifRepository;
        }
    }
}
