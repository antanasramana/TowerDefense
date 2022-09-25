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

        [HttpPost]
        public async Task<ActionResult<GetGridResponse>> GetGrid(GetGridRequest getGridRequest)
        {
            var getInventoryItemsResponse = battleHandler.GetGridItems(getGridRequest);
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
