using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Controllers
{

    [Route("api/grid")]
    [ApiController]
    public class GridController : ControllerBase
    {
        private readonly BattleHandler battleHandler;
        public GridController()
        {
            this.battleHandler = new BattleHandler();
        }

        [HttpGet("{playerName}")]
        public async Task<ActionResult<GetGridResponse>> GetGrid(string playerName)
        {
            var getInventoryItemsResponse = battleHandler.GetGridItems(playerName);
            return Ok(getInventoryItemsResponse);
        }
        [HttpPost("add")]
        public async Task<ActionResult<AddGridItemResponse>> AddGridItem(AddGridItemRequest addGridItemRequest)
        {
            var AddGridItemResponse = battleHandler.AddGridItem(addGridItemRequest);
            return Ok(AddGridItemResponse);
        }
    }
}
