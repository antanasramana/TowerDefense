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

        [HttpPost]
        public async Task<ActionResult<GetInventoryItemsResponse>> GetItems(GetInventoryItemsRequest getInventoryItemsRequest)
        {
            try
            {
                 var getInventoryItemsResponse = battleHandler.GetInventoryItems(getInventoryItemsRequest);
                 return Ok(getInventoryItemsResponse);
            }
            catch (Exception e)
            { }

            return Ok();
        }
    }
}
