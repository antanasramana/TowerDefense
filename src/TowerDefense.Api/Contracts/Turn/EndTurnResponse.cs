using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Contracts.Turn
{
    public class EndTurnResponse
    {
        public GridItem[] GridItems { get; set; }

        public List<AttackResult> PlayerAttackResults{ get; set; }

        public List<AttackResult> EnemyAttackResults { get; set; }
    }
}
