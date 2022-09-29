using AutoMapper;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Bootstrap.AutoMapper
{
    public class ArenaGridMapProfile : Profile
    {
        public ArenaGridMapProfile()
        {
            CreateMap<ArenaGrid, AddGridItemResponse>()
                .ForMember(dest => dest.GridItems, opt => opt.MapFrom(src => src.GridItems));
        }
    }
}
