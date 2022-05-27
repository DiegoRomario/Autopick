using AutoMapper;
using Autopick.Api.Domain;
namespace Autopick.Api.Models.Mappings
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<Account, AccountModel>().ReverseMap();
            CreateMap<Group, GroupModel>().ReverseMap();
            CreateMap<Modality, ModalityModel>().ReverseMap();
            CreateMap<Skill, SkillModel>().ReverseMap();
            CreateMap<Player, PlayerModel>().ReverseMap();
            CreateMap<Match, MatchModel>().ReverseMap();
            CreateMap<Team, TeamModel>().ReverseMap();
        }
    }
}
