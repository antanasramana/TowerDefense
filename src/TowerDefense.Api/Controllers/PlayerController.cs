using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.GameLogic.Factories;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.Contracts.Player;
using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.Enums;

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

        public PlayerController (IBattleHandlerFacade battleHandler, 
            IInitialGameSetupHandler initialGameSetupHandler, 
            IPlayerHandler playerHandler, 
            IMapper mapper)
        {
            _battleHandler = battleHandler;
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
            _battleHandler.HandleEndTurn(endTurnRequest.PlayerName);

            return Ok();
        }
    }
}
