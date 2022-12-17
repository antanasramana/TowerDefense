using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.Contracts.Perks
{
    public class GetPerksResponse
    {
        public IEnumerable<IPerk> Perks { get; set; }
    }
}
