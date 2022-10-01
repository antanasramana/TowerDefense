using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IBattleHandler _battleHandler;
        private readonly IInitialGameSetupHandler _initialGameSetupHandler;

        public PlayerController (IBattleHandler battleHandler, IInitialGameSetupHandler initialGameSetupHandler)
        {
            _battleHandler = battleHandler;
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
            _battleHandler.HandleEndTurn(endTurnRequest.PlayerName);

            return Ok();
        }
    }
}
