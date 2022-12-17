using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.Contracts.Player;
using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.Contracts.Command;

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
        private readonly ITurnHandler _turnHandler;

        public PlayerController (IGameHandler gameHandler,
            IInitialGameSetupHandler initialGameSetupHandler, 
            IPlayerHandler playerHandler, 
            ITurnHandler turnHandler,
            IMapper mapper)
        {
            _gameHandler = gameHandler;
            _initialGameSetupHandler = initialGameSetupHandler;
            _playerHandler = playerHandler;
            _turnHandler = turnHandler;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<AddNewPlayerResponse> Register([FromBody] AddNewPlayerRequest addPlayerRequest)
        {
            var player = _initialGameSetupHandler.AddNewPlayer(addPlayerRequest.PlayerName);

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
            _turnHandler.TryEndTurn(endTurnRequest.PlayerName);
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

        [HttpPost("place-item")]
        public ActionResult PlaceItemOnGrid(ExecuteCommandRequest request)
        {
            var player = _playerHandler.GetPlayer(request.PlayerName);

            var inventory = player.Inventory;
            var requestedItem = inventory.Items.FirstOrDefault(x => x.Id == request.InventoryItemId);

            if (requestedItem == null)
            {
                return Ok();
            }

            var playersGridItems = player.ArenaGrid.GridItems;
            var selectedGridItem = playersGridItems[request.GridItemId.Value];

            inventory.Items.Remove(requestedItem);
            selectedGridItem.Item = requestedItem;
            return Ok();
        }

        [HttpPost("command")]
        public ActionResult ExecuteCommand(ExecuteCommandRequest commandRequest)
        {
            return Ok();
        }

        [HttpPost("command/text")]
        public ActionResult InterpretCommand(InterpretCommandRequest commandRequest)
        {
            return Ok();
        }
    }
}
