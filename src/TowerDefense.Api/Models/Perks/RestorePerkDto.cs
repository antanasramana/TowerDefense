namespace TowerDefense.Api.Models.Perks
{
    public class RestorePerkDto : IPerkDto, IPersonalPerk
    {
        public int Id { get; init; }
        public string Name => "Restore!";
        public PerkType Type => PerkType.Restore;
    }
}
