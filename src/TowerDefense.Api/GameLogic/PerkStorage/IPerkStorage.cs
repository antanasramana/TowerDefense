using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public interface IPerkStorage
    {
        public IEnumerable<IPerkDto> Perks { get; set; }
    }
}
