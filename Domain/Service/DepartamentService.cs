using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Service
{
    public class DepartamentService : ServiceBase<Departaments>, IDepartamentService
    {
        private readonly IDepartamentRepository _departamentRepository;
        public DepartamentService(IDepartamentRepository departamentRepository) : base(departamentRepository)
        {
            _departamentRepository = departamentRepository;
        }
    }
}
