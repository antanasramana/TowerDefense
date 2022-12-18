namespace TowerDefense.Api.GameLogic.Items;

public class SpecialItemStats : IItemStats
{
    public int Price { get; set; } = 500;
    public int Health { get; set; } = 50;
    public int Damage { get; set; } = 25;
}