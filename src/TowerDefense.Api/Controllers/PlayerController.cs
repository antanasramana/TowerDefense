using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Data;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IBattleOrchestrator _battleOrchestrator;
        private readonly IInitialGameSetupHandler _initialGameSetupHandler;

        public PlayerController (IBattleOrchestrator battleOrchestrator, IInitialGameSetupHandler initialGameSetupHandler)
        {
            _battleOrchestrator = battleOrchestrator;
            _initialGameSetupHandler = initialGameSetupHandler;
        }

        [HttpPost]
        public async Task<ActionResult<AddNewPlayerResponse>> Register([FromBody] AddNewPlayerRequest addPlayerRequest)
        {
            _initialGameSetupHandler.AddNewPlayerToGame(addPlayerRequest);

            return Ok(new AddNewPlayerResponse { PlayerName = addPlayerRequest.PlayerName });
        }

        [HttpPost("endturn")]
        public async Task<ActionResult> EndTurn(EndTurnRequest endTurnRequest)
        {
            _battleOrchestrator.HandleEndTurn(endTurnRequest.PlayerName);

            return Ok();
        }
    }
}
