using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public interface IPerkStorage
    {
        public IEnumerable<Perk> Perks { get; set; }
    }
}
