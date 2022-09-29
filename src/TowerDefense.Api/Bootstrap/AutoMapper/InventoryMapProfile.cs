using AutoMapper;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Bootstrap.AutoMapper
{
    public class InventoryMapProfile : Profile
    {
        public InventoryMapProfile()
        {
            CreateMap<Inventory, GetInventoryItemsResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
