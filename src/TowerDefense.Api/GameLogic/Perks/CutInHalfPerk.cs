namespace TowerDefense.Api.GameLogic.Perks
{
    public class CutInHalfPerk : IPerk
    {
        public int Id { get; init; }
        public string Name => "Cut Enemy Money in Half!";
        public PerkType Type => PerkType.CutInHalf;
    }
}
