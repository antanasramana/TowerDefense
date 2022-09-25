using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Controllers
{
    [Route("api/shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly BattleHandler battleHandler;

        public ShopController()
        {
            this.battleHandler = new BattleHandler();
        }

        [HttpGet]
        public async Task<ActionResult<GetShopItemsResponse>> GetItems()
        {
            var getItemsResponse = battleHandler.GetShopItems();

            return Ok(getItemsResponse);
        }

        [HttpPost]
        public async Task<ActionResult> BuyItem(BuyShopItemRequest buyShopItemRequest)
        {
            battleHandler.BuyShopItem(buyShopItemRequest);

            return Ok();
        }
    }
}
