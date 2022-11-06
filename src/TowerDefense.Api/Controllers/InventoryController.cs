using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.Contracts.Inventory;

namespace TowerDefense.Api.Controllers
{

    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryHandler _inventoryHandler;
        private readonly IMapper _mapper;
        public InventoryController(IInventoryHandler inventoryHandler, IMapper mapper)
        {
            _inventoryHandler = inventoryHandler;
            _mapper = mapper;
        }

        [HttpGet("{playerName}")]
        public ActionResult<GetInventoryItemsResponse> GetItems(string playerName)
        {
            var inventory = _inventoryHandler.GetPlayerInventory(playerName);

            var getInventoryItemsResponse = _mapper.Map<GetInventoryItemsResponse>(inventory);

            return Ok(getInventoryItemsResponse);
        }
    }
}
