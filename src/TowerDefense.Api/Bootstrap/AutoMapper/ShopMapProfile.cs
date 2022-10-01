using AutoMapper;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Bootstrap.AutoMapper
{
    public class ShopMapProfile : Profile
    {
        public ShopMapProfile()
        {
            CreateMap<Shop, GetShopItemsResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
