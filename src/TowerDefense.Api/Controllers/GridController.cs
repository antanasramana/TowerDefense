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
        private readonly ICommandHandler _commandHandler;
        public GridController(IGridHandler gridHandler, IMapper mapper, ICommandHandler commandHandler)
        {
            _gridHandler = gridHandler;
            _mapper = mapper;
            _commandHandler = commandHandler;
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
            _commandHandler.ExecuteCommandForPlayer(addGridItemRequest.PlayerName, placeCommand);
          
            return Ok();
        }

        [HttpPost("upgrade/{playerName}/{gridItemId}")]
        public ActionResult UpgradeItem(string playerName, int gridItemId)
        {
            var upgradeCommand = new UpgradeCommand(gridItemId);
            _commandHandler.ExecuteCommandForPlayer(playerName, upgradeCommand);

            return Ok();  
        }

        [HttpPost("remove/{playerName}/{gridItemId}")]
        public ActionResult RemoveItem(string playerName, int gridItemId)
        {
            var removeCommand = new RemoveCommand(gridItemId);
            _commandHandler.ExecuteCommandForPlayer(playerName, removeCommand);

            return Ok();
        }

        [HttpPost("undo/{playerName}")]
        public ActionResult UndoCommand(string playerName)
        {
            var placeCommand = new UndoCommand();
            _commandHandler.ExecuteCommandForPlayer(playerName, placeCommand);

            return Ok();
        }
    }
}
