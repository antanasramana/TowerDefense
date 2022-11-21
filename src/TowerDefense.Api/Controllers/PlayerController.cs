using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.GameLogic.Factories;
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
        private readonly IBattleHandlerFacade _battleHandler;
        private readonly IInitialGameSetupHandler _initialGameSetupHandler;
        private readonly IPlayerHandler _playerHandler;
        private readonly IMapper _mapper;
        private readonly IGameMediator _gameMediator;

        public PlayerController (IBattleHandlerFacade battleHandler, 
            IGameMediator gameMediator,
            IInitialGameSetupHandler initialGameSetupHandler, 
            IPlayerHandler playerHandler, 
            IMapper mapper)
        {
            _battleHandler = battleHandler;
            _gameMediator = gameMediator;
            _initialGameSetupHandler = initialGameSetupHandler;
            _playerHandler = playerHandler;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<AddNewPlayerResponse> Register([FromBody] AddNewPlayerRequest addPlayerRequest)
        {
            IAbstractLevelFactory abstractLevelFactory = addPlayerRequest.Level switch
            {
                Level.First => new FirstLevelFactory(),
                Level.Second => new SecondLevelFactory(),
                Level.Third => new ThirdLevelFactory(),
                _ => throw new ArgumentOutOfRangeException()
            };

            var player = _initialGameSetupHandler.AddNewPlayerToGame(addPlayerRequest.PlayerName, abstractLevelFactory);
            _initialGameSetupHandler.SetArenaGridForPlayer(addPlayerRequest.PlayerName, abstractLevelFactory);
            _initialGameSetupHandler.SetShopForPlayer(addPlayerRequest.PlayerName, abstractLevelFactory);
            _initialGameSetupHandler.SetPerkStorageForPlayer(addPlayerRequest.PlayerName, abstractLevelFactory);
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
    }
}
