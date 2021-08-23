using Api.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PRODUTO, PRODUTO_DTO>().ReverseMap();
            CreateMap<PRODUTO_COSIF, PRODUTO_COSIF_DTO>().ReverseMap();
            CreateMap<MOVIMENTO_MANUAL, MOVIMENTO_MANUAL_DTO>().ReverseMap();
            CreateMap<Departaments, DepartamentDto>().ReverseMap();
        }
        
    }
}