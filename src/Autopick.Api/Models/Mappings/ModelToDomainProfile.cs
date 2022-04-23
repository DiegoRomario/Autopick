using AutoMapper;
using Autopick.Api.Domain;
using Autopick.Api.ViewModels;

namespace Autopick.Api.Models.Mappings
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<Account, AccountModel>().ReverseMap();
        }
    }
}
