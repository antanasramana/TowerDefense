using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Contracts.Grid
{
    public class GetGridItemResponse
    {
        public int Id { get; set; }
        public ItemType ItemType { get; set; }

        public int Level { get; set; }
    }
}
