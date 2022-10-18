using AutoMapper;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Contracts.Grid;

namespace TowerDefense.Api.Bootstrap.AutoMapper
{
    public class ArenaGridMapProfile : Profile
    {
        public ArenaGridMapProfile()
        {
            CreateMap<IArenaGrid, AddGridItemResponse>()
                .ForMember(dest => dest.GridItems, opt => opt.MapFrom(src => src.GridItems));
            
            CreateMap<IArenaGrid, GetGridResponse>()
                .ForMember(dest => dest.GridItems, opt => opt.MapFrom(src => src.GridItems));

            CreateMap<GridItem, GetGridItemResponse>()
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.Item.ItemType));
        }
    }
}
