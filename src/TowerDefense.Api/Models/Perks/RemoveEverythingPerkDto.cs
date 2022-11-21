namespace TowerDefense.Api.Models.Perks
{
    public class RemoveEverythingPerkDto : IPerkDto
    {
        public int Id { get; init; }
        public string Name => "Remove Everything!";
        public PerkType Type => PerkType.RemoveEverything;
    }
}
