using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Hubs;

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
