using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.Contracts.Command;
using TowerDefense.Api.Contracts.Grid;

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
        public ActionResult<GetGridResponse> GetGrid(string playerName)
        {
            var arenaGrid = _gridHandler.GetGridItems(playerName);

            var getGridResponse = _mapper.Map<GetGridResponse>(arenaGrid);

            return Ok(getGridResponse);
        }
    }
}
