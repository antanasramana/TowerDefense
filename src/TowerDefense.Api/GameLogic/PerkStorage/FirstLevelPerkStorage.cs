using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.GameLogic.PerkStorage
{
    public class FirstLevelPerkStorage : IPerkStorage
    {
        public IEnumerable<IPerkDto> Perks { get; set; } = new IPerkDto[] {
            new CutInHalfPerkDto{ Id = 1 },
        };
    }
}
