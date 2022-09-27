using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Data;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly BattleHandler battleHandler;

        public PlayerController (IHubContext<GameHub> hubContext)
        {
            this.battleHandler = new BattleHandler(hubContext);
        }

        [HttpPost]
        public async Task<ActionResult<AddPlayerResponse>> Register([FromBody] AddPlayerRequest addPlayerRequest)
        {
            battleHandler.HandleNewPlayer(addPlayerRequest);

            return Ok(new AddPlayerResponse { Name = addPlayerRequest.PlayerName });
        }

        [HttpPost("endturn")]
        public async Task<ActionResult> EndTurn(EndTurnRequest endTurnRequest)
        {
            battleHandler.HandleEndTurn(endTurnRequest.PlayerName);

            return Ok();
        }
    }
}
