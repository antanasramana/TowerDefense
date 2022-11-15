using AutoMapper;
using TowerDefense.Api.Contracts.Perks;
using TowerDefense.Api.GameLogic.PerkStorage;

namespace TowerDefense.Api.Bootstrap.AutoMapper
{
    public class PerkStorageProfile : Profile
    {
        public PerkStorageProfile()
        {
            CreateMap<IPerkStorage, GetPerksResponse>()
                .ForMember(dest => dest.Perks, opt => opt.MapFrom(src => src.Perks))
                .ReverseMap();
        }
    }
}
