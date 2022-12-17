namespace TowerDefense.Api.GameLogic.Attacks
{
    public class AttackDeclaration
    {
        public bool PlayerWasHit { get; set; } = false;
        public int GridItemId { get; set; }
        public int Damage { get; set; }
        public int EarnedMoney { get; set; } = 0;
    }
}
