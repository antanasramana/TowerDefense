using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public class ThirdLevelPerkStorage : IPerkStorage
    {
        public IEnumerable<IPerk> Perks { get; set; } = new IPerk[] {
            new CutInHalfPerk{ Id = 1 },
            new RestorePerk{ Id = 2 },
            new RemoveEverythingPerk{ Id = 3 },
            new BackInTimePerk{ Id = 4 }
        };
    }
}
