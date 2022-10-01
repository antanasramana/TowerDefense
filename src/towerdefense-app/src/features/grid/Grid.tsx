import React from 'react';
import GridTile from './GridTile';
import './Grid.css';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { useAddGridItemMutation, setPlayerGridItems } from './GridSlice';
import { getInventoryItems } from '../inventory/InventorySlice';
import { AddGridItemRequest } from '../../contracts/AddGridItemRequest';

interface Props {
  isEnemy: boolean;
}

const Grid: React.FC<Props> = (props) => {
	const dispatch = useAppDispatch();

	// redux State
	const selectedInventoryItem = useAppSelector((state) => state.inventory.selectedItem);
	const playerName = useAppSelector((state) => state.player.name);
	const playerGrid = useAppSelector((state) => state.grid.playerGridItems);
	const enemyGrid = useAppSelector((state) => state.grid.enemyGridItems);

	// redux api
	const [addGridItem] = useAddGridItemMutation();

	// methods
	function onGridTileClick(id: number) {
		if (!selectedInventoryItem) {
			return;
		}

		const addGridItemRequest: AddGridItemRequest = {
			playerName: playerName,
			inventoryItemId: selectedInventoryItem,
			gridItemId: id,
		};

		addGridItem(addGridItemRequest)
			.unwrap()
			.then((res) => {
				dispatch(setPlayerGridItems(res.gridItems));
				dispatch(getInventoryItems());
			});
	}

	return (
		<div className={props.isEnemy ? 'grid enemy' : 'grid'}>
			{props.isEnemy
				? enemyGrid.map((item, index) => (
					<GridTile
						key={index}
						id={item.id}
						selectable={!props.isEnemy}
						onTileClick={() => {0;}}
						tileType={item.itemType}
					/>
				))
				: playerGrid.map((item, index) => (
					<GridTile
						key={index}
						id={item.id}
						selectable={!props.isEnemy}
						onTileClick={onGridTileClick}
						tileType={item.itemType}
					/>
				))}
		</div>
	);
};

export default Grid;
