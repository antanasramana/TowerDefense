using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.Contracts.Player;
using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.Enums;
using TowerDefense.Api.GameLogic.Mediator;

namespace TowerDefense.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IInitialGameSetupHandler _initialGameSetupHandler;
        private readonly IPlayerHandler _playerHandler;
        private readonly IMapper _mapper;
        private readonly IGameMediator _gameMediator;

        public PlayerController (IGameMediator gameMediator,
            IInitialGameSetupHandler initialGameSetupHandler, 
            IPlayerHandler playerHandler, 
            IMapper mapper)
        {
            _gameMediator = gameMediator;
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
            _initialGameSetupHandler.SetLevel(addPlayerRequest.Level);

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
            _gameMediator.Notify(this, MediatorEvent.PlayerEndedTurn, endTurnRequest.PlayerName);
            return Ok();
        }
        [HttpPost("reset")]
        public ActionResult Reset()
        {
            _gameMediator.Notify(this, MediatorEvent.ResetGame, null);
            return Ok();
        }
    }
}
