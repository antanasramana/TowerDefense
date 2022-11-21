namespace TowerDefense.Api.Models.Perks
{
    public class BackInTimePerkDto : IPerkDto, IPersonalPerk
    {
        public int Id { get; init; }
        public string Name => "Back in Time!";
        public PerkType Type => PerkType.BackInTime;
    }
}
