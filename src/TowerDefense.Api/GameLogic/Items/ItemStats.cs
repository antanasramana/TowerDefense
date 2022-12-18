namespace TowerDefense.Api.GameLogic.Items
{
    public interface IItemStats
    {
        int Price { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
    }
}
