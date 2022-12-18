namespace TowerDefense.Api.GameLogic.Items;

public class BasicDefenseItemStats : IItemStats
{
    public int Price { get; set; } = 50;
    public int Health { get; set; } = 50;
    public int Damage { get; set; } = 0;
}