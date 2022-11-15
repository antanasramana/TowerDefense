using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public class ThirdLevelPerkStorage : IPerkStorage
    {
        public IEnumerable<Perk> Perks { get; set; } = new Perk[] {
            new Perk{ Id = 1, Name = "Cut Everything in Half!", Type = PerkType.CutInHalf },
            new Perk{ Id = 2, Name = "Restore Everything!", Type = PerkType.Restore },
            new Perk{ Id = 3, Name = "Remove Everything!", Type = PerkType.RemoveEverything },
            new Perk{ Id = 4, Name = "Back in Time!", Type = PerkType.BackInTime },
        };
    }
}
