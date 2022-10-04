using AutoMapper;
using TowerDefense.Api.Contracts.Player;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Bootstrap.AutoMapper
{
    public class PlayerMapProfile : Profile
    {
        public PlayerMapProfile()
        {
            CreateMap<IPlayer, AddNewPlayerResponse>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Name));
            CreateMap<IPlayer, GetPlayerInfoResponse>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
