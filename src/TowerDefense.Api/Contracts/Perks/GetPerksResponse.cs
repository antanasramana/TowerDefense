using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.Contracts.Perks
{
    public class GetPerksResponse
    {
        public IEnumerable<IPerkDto> Perks { get; set; }
    }
}
