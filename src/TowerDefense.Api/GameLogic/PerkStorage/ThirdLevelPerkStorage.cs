using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public class ThirdLevelPerkStorage : IPerkStorage
    {
        public IEnumerable<IPerkDto> Perks { get; set; } = new IPerkDto[] {
            new CutInHalfPerkDto{ Id = 1 },
            new RestorePerkDto{ Id = 2 },
            new RemoveEverythingPerkDto{ Id = 3 },
            new BackInTimePerkDto{ Id = 4 }
        };
    }
}
