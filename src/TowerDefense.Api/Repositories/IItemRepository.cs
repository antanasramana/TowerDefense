using TowerDefense.Api.Models;

namespace TowerDefense.Api.Repositories
{
    public interface IItemRepository
    {
        public IEnumerable<Item> Items { get; }
    }
}
