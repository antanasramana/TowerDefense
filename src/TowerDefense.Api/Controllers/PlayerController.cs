using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.Contracts.Player;
using TowerDefense.Api.Contracts.Turn;

namespace TowerDefense.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IInitialGameSetupHandler _initialGameSetupHandler;
        private readonly IPlayerHandler _playerHandler;
        private readonly IMapper _mapper;
        private readonly IGameHandler _gameHandler;

        public PlayerController (IGameHandler gameHandler,
            IInitialGameSetupHandler initialGameSetupHandler, 
            IPlayerHandler playerHandler, 
            IMapper mapper)
        {
            _gameHandler = gameHandler;
            _initialGameSetupHandler = initialGameSetupHandler;
            _playerHandler = playerHandler;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<AddNewPlayerResponse> Register([FromBody] AddNewPlayerRequest addPlayerRequest)
        {
            var player = _initialGameSetupHandler.AddNewPlayerToGame(addPlayerRequest.PlayerName);
            _initialGameSetupHandler.SetArenaGridForPlayer(addPlayerRequest.PlayerName);
            _initialGameSetupHandler.SetShopForPlayer(addPlayerRequest.PlayerName);
            _initialGameSetupHandler.SetPerkStorageForPlayer(addPlayerRequest.PlayerName);

            var addNewPlayerResponse = _mapper.Map<AddNewPlayerResponse>(player);

            return Ok(addNewPlayerResponse);
        }

        [HttpGet("{playerName}")]
        public ActionResult<GetPlayerInfoResponse> GetInfo(string playerName)
        {
            var player = _playerHandler.GetPlayer(playerName);
            var getPlayerInfoResponse = _mapper.Map<GetPlayerInfoResponse>(player);

            return Ok(getPlayerInfoResponse);
        }

        [HttpPost("endturn")]
        public ActionResult EndTurn(EndTurnRequest endTurnRequest)
        {
            _gameHandler.PlayerEndedTurn(endTurnRequest.PlayerName);
            return Ok();
        }

        /// <summary>
        /// Clears game state and restarts game
        /// </summary>
        /// <returns></returns>
        [HttpPost("reset")]
        public ActionResult Reset()
        {
            _gameHandler.ResetGame();
            return Ok();
        }
    }
}
