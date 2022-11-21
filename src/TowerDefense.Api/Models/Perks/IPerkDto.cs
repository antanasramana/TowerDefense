namespace TowerDefense.Api.Models.Perks
{
    public interface IPerkDto
    {
        public int Id { get; init; }
        public string Name { get; }
        public PerkType Type { get; }
    }
}