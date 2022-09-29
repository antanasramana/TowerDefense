using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Controllers
{

    [Route("api/grid")]
    [ApiController]
    public class GridController : ControllerBase
    {
        private readonly IBattleOrchestrator _battleOrchestrator;
        public GridController(IBattleOrchestrator battleOrchestrator)
        {
            _battleOrchestrator = battleOrchestrator;
        }

        [HttpGet("{playerName}")]
        public async Task<ActionResult<GetGridResponse>> GetGrid(string playerName)
        {
            var getInventoryItemsResponse = _battleOrchestrator.GetGridItems(playerName);
            return Ok(getInventoryItemsResponse);
        }

        [HttpPost("add")]
        public async Task<ActionResult<AddGridItemResponse>> AddGridItem(AddGridItemRequest addGridItemRequest)
        {
            var AddGridItemResponse = _battleOrchestrator.AddGridItem(addGridItemRequest);
            return Ok(AddGridItemResponse);
        }
    }
}
