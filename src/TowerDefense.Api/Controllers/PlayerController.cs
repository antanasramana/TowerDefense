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
        public async Task<ActionResult<AddPlayerResponse>> Register([FromBody] AddPlayerRequest player)
        {
            battleHandler.HandleNewPlayer(player);

            return Ok(new AddPlayerResponse { Name = player.Name });
        }
        // this should be GET request...
        [HttpPost("get")]
        public async Task<ActionResult<Player>> GetPlayer(GetPlayerRequest getPlayerRequest)
        {
            var player = battleHandler.GetPlayer(getPlayerRequest.PlayerName);

            return Ok(player);
        }

        [HttpPost("endturn")]
        public async Task<ActionResult> EndTurn(AddPlayerRequest player)
        {
            battleHandler.HandleEndTurn(player.Name);

            return Ok();
        }
    }
}
