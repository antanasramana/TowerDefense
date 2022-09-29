using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.Controllers
{

    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IBattleOrchestrator _battleOrchestrator;
        public InventoryController(IBattleOrchestrator battleOrchestrator)
        {
            _battleOrchestrator = battleOrchestrator;
        }

        [HttpGet("{playerName}")]
        public async Task<ActionResult<GetInventoryItemsResponse>> GetItems(string playerName)
        {
            var getInventoryItemsResponse = _battleOrchestrator.GetInventoryItems(playerName);
            return Ok(getInventoryItemsResponse);
        }
    }
}
