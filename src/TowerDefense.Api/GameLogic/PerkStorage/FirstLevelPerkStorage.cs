using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public class FirstLevelPerkStorage : IPerkStorage
    {
        public IEnumerable<IPerk> Perks { get; set; } = new IPerk[] {
            new CutInHalfPerk{ Id = 1 },
        };
    }
}
