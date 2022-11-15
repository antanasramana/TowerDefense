using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TowerDefense.Api.Contracts.Perks;
using TowerDefense.Api.GameLogic.Handlers;

namespace TowerDefense.Api.Controllers
{
    [Route("api/perks")]
    [ApiController]
    public class PerksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPerkHandler _perkHandler;
        public PerksController(IMapper mapper, IPerkHandler perkHandler)
        {
            _mapper = mapper;
            _perkHandler = perkHandler;
        }

        [HttpGet("{playerName}")]
        public ActionResult<GetPerksResponse> GetPerks(string playerName)
        {
            var perks = _perkHandler.GetPerks(playerName);

            var perksResponse = _mapper.Map<GetPerksResponse>(perks);

            return Ok(perksResponse);
        }

        [HttpPost]
        public ActionResult PostPerk(ApplyPerkRequest applyPerkRequest)
        {
            _perkHandler.ApplyPerkToOpponent(applyPerkRequest.PlayerName, applyPerkRequest.PerkId);

            return Ok();
        }
    }
}
