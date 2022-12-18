namespace TowerDefense.Api.GameLogic.Items;

public class DefaultZeroItemStats : IItemStats
{
    public int Price { get; set; } = 0;
    public int Health { get; set; } = 0;
    public int Damage { get; set; } = 0;
}