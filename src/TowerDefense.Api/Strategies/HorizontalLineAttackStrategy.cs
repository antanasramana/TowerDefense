﻿using TowerDefense.Api.ArenaAdapter;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Constants;
using static TowerDefense.Api.Strategies.StrategyHelper;

namespace TowerDefense.Api.Strategies
{
    public class HorizontalLineAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var attackingItemRow = attackingGridItemId / Game.MaxGridGridItemsInRow;
            IMatrix opponentsMatrix = new ArenaGridAdapter(opponentsArenaGrid);
            var affectedGridItems = opponentsMatrix.GetItemsByRow(attackingItemRow)
                                                   .OrderByDescending(x => x.Id);

            return affectedGridItems.Select(x => x.Id);
        }
    }
}
