namespace TowerDefense.Api.Models.Perks
{
    public class CutInHalfPerk : IPerk
    {
        public int Id { get; init; }
        public string Name => "Cut Everything in Half!";
        public PerkType Type => PerkType.CutInHalf;
    }
}
