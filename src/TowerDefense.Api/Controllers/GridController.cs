using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Controllers
{

    [Route("api/grid")]
    [ApiController]
    public class GridController : ControllerBase
    {
        private readonly IGridHandler _gridHandler;
        private readonly IMapper _mapper;
        public GridController(IGridHandler gridHandler, IMapper mapper)
        {
            _gridHandler = gridHandler;
            _mapper = mapper;
        }

        [HttpGet("{playerName}")]
        public async Task<ActionResult<GetGridResponse>> GetGrid(string playerName)
        {
            var getInventoryItemsResponse = _gridHandler.GetGridItems(playerName);
            return Ok(getInventoryItemsResponse);
        }

        [HttpPost("add")]
        public async Task<ActionResult<AddGridItemResponse>> AddGridItem(AddGridItemRequest addGridItemRequest)
        {
            var arenaGrid = _gridHandler.AddGridItem(addGridItemRequest.PlayerName, addGridItemRequest.InventoryItemId, addGridItemRequest.GridItemId);

            var arenaGridItemResponse = _mapper.Map<AddGridItemResponse>(arenaGrid);

            return Ok(arenaGridItemResponse);
        }
    }
}
