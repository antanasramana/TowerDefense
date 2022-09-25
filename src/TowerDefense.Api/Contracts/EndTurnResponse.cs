using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Battle;

namespace TowerDefense.Api.Contracts
{
    public class EndTurnResponse
    {
        public GridItem[] GridItems { get; set; }
    }
}
