namespace TowerDefense.Api.GameLogic.Perks
{
    public interface IPerk
    {
        public int Id { get; init; }
        public string Name { get; }
        public PerkType Type { get; }
    }
}