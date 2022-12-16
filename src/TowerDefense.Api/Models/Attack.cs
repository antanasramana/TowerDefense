namespace TowerDefense.Api.Models
{
    public class Attack
    {
        public List<AttackDeclaration> DirectAttackDeclarations { get; set; }
        public List<AttackDeclaration> ItemAttackDeclarations { get; set; }
    }
}
