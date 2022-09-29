using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.Controllers
{
    [Route("api/shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IBattleOrchestrator _battleOrchestrator;

        public ShopController(IBattleOrchestrator battleOrchestrator)
        {
            _battleOrchestrator = battleOrchestrator;
        }

        [HttpGet]
        public async Task<ActionResult<GetShopItemsResponse>> GetItems()
        {
            var getItemsResponse = _battleOrchestrator.GetShopItems();

            return Ok(getItemsResponse);
        }

        [HttpPost]
        public async Task<ActionResult> BuyItem(BuyShopItemRequest buyShopItemRequest)
        {
            _battleOrchestrator.BuyShopItem(buyShopItemRequest);

            return Ok();
        }
    }
}
