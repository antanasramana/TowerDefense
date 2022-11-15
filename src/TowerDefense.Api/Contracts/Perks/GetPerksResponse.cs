using TowerDefense.Api.Models;

namespace TowerDefense.Api.Contracts.Perks
{
    public class GetPerksResponse
    {
        public IEnumerable<Perk> Perks { get; set; }
    }
}
