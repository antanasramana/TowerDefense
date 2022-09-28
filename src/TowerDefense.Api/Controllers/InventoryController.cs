using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Controllers
{

    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly BattleHandler battleHandler;
        public InventoryController()
        {
            this.battleHandler = new BattleHandler();
        }

        [HttpGet("{playerName}")]
        public async Task<ActionResult<GetInventoryItemsResponse>> GetItems(string playerName)
        {
            var getInventoryItemsResponse = battleHandler.GetInventoryItems(playerName);
            return Ok(getInventoryItemsResponse);
        }
    }
}
