﻿using TowerDefense.Api.GameLogic.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Constants;
using static TowerDefense.Api.GameLogic.Strategies.StrategyHelper;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class HorizontalLineAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var attackingItemRow = attackingGridItemId / Constants.TowerDefense.MaxGridGridItemsInRow;
            IMatrix opponentsMatrix = new ArenaGridAdapter(opponentsArenaGrid);
            var affectedGridItems = opponentsMatrix.GetItemsByRow(attackingItemRow)
                                                    .Where(x => IsItemDamageable(x))
                                                    .OrderByDescending(x => x.Id);

            return affectedGridItems.Select(x => x.Id);
        }
    }
}
