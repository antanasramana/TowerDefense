using TowerDefense.Api.GameLogic.Perks;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public interface IPerkStorage
    {
        public IEnumerable<IPerk> Perks { get; set; }
    }
}
