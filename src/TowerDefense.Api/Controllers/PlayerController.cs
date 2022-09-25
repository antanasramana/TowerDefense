using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Data;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Player;

namespace TowerDefense.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly BattleHandler battleHandler;

        public PlayerController ()
        {
            this.battleHandler = new BattleHandler();
        }

        [HttpPost]
        public async Task<ActionResult<AddPlayerResponse>> Register([FromBody] AddPlayerRequest player)
        {
            battleHandler.HandleNewPlayer(player);

            return Ok(new AddPlayerResponse { Name = player.Name });
        }
    }
}
