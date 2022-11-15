using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public class FirstLevelPerkStorage : IPerkStorage
    {
        public IEnumerable<Perk> Perks { get; set; } = new Perk[] {
            new Perk{ Id = 1, Name = "Cut Everything in Half!", Type = PerkType.CutInHalf },
        };
    }
}
