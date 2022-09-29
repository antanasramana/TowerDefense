using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Battle.Handlers;
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
        public ActionResult<AddNewPlayerResponse> Register([FromBody] AddNewPlayerRequest addPlayerRequest)
        {
            _initialGameSetupHandler.AddNewPlayerToGame(addPlayerRequest.PlayerName);

            return Ok(new AddNewPlayerResponse { PlayerName = addPlayerRequest.PlayerName });
        }

        [HttpPost("endturn")]
        public ActionResult EndTurn(EndTurnRequest endTurnRequest)
        {
            _battleOrchestrator.HandleEndTurn(endTurnRequest.PlayerName);

            return Ok();
        }
    }
}
