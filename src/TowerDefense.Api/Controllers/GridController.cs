using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Command;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Contracts.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Controllers
{

    [Route("api/grid")]
    [ApiController]
    public class GridController : ControllerBase
    {
        private readonly IGridHandler _gridHandler;
        private readonly IMapper _mapper;
        private readonly IPlayerHandler _playerHandler;
        public GridController(IGridHandler gridHandler, IMapper mapper, IPlayerHandler playerHandler)
        {
            _gridHandler = gridHandler;
            _mapper = mapper;
            _playerHandler = playerHandler;
        }

        [HttpGet("{playerName}")]
        public ActionResult<GetGridResponse> GetGrid(string playerName)
        {
            var arenaGrid = _gridHandler.GetGridItems(playerName);

            var getGridResponse = _mapper.Map<GetGridResponse>(arenaGrid);

            return Ok(getGridResponse);
        }

        [HttpPost("add")]
        public ActionResult AddGridItem(AddGridItemRequest addGridItemRequest)
        {
            var placeCommand = new PlaceCommand(addGridItemRequest.InventoryItemId, addGridItemRequest.GridItemId);
            var player = _playerHandler.GetPlayer(addGridItemRequest.PlayerName);
            player.CommandExecutor.Execute(placeCommand);
          
            return Ok();
        }

        [HttpPost("upgrade/{playerName}/{gridItemId}")]
        public ActionResult UpgradeItem(string playerName, int gridItemId)
        {
            var upgradeCommand = new UpgradeCommand(gridItemId);
            var player = _playerHandler.GetPlayer(playerName);
            player.CommandExecutor.Execute(upgradeCommand);

            return Ok();  
        }

        [HttpPost("remove/{playerName}/{gridItemId}")]
        public ActionResult RemoveItem(string playerName, int gridItemId)
        {
            var removeCommand = new RemoveCommand(gridItemId);
            var player = _playerHandler.GetPlayer(playerName);
            player.CommandExecutor.Execute(removeCommand);

            return Ok();
        }

        [HttpPost("undo/{playerName}")]
        public ActionResult UndoCommand(string playerName)
        {
            var placeCommand = new UndoCommand();
            var player = _playerHandler.GetPlayer(playerName);
            player.CommandExecutor.Execute(placeCommand);

            return Ok();
        }
    }
}
