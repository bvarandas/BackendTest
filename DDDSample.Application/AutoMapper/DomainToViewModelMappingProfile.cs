using AutoMapper;
using DDDSample.Application.ViewModels;
using DDDSample.Domain.Models;

namespace DDDSample.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
