﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Contracts.Shop;

namespace TowerDefense.Api.Controllers
{
    [Route("api/shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopHandler _shopHandler;
        private readonly IMapper _mapper;

        public ShopController(IShopHandler shopHandler, IMapper mapper)
        {
            _shopHandler = shopHandler;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpGet("{playerName}")]
        public ActionResult<GetShopItemsResponse> GetItems(string playerName)
        {
            var shop = _shopHandler.GetPlayerShop(playerName);

            var getShopItemsResponse = _mapper.Map<GetShopItemsResponse>(shop);

            return Ok(getShopItemsResponse);
        }

        [HttpPost]
        public IActionResult BuyItem(BuyShopItemRequest buyShopItemRequest)
        {
            _shopHandler.BuyItem(buyShopItemRequest.PlayerName, buyShopItemRequest.ItemId);

            return Ok();
        }
    }
}
