namespace TowerDefense.Api.GameLogic.Items;

public class MediumCostHighDamageItemStats : IItemStats
{
    public int Price { get; set; } = 100;
    public int Health { get; set; } = 25;
    public int Damage { get; set; } = 60;
}