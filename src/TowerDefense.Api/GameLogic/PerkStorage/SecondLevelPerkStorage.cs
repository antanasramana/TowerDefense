using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public class SecondLevelPerkStorage : IPerkStorage
    {
        public IEnumerable<IPerkDto> Perks { get; set; } = new IPerkDto[] {
            new CutInHalfPerkDto{ Id = 1 },
            new RestorePerkDto{ Id = 2 }
        };
    }
}
