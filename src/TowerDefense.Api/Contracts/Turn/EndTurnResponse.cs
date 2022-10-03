using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Contracts.Turn
{
    public class EndTurnResponse
    {
        public GridItem[] GridItems { get; set; }
    }
}
