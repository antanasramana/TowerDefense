import React, { useEffect, useState } from 'react';
import GridTile from './GridTile';
import './Grid.css';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { executePlaceCommand, getPlayerGridItems } from './GridSlice';
import { getInventoryItems } from '../inventory/InventorySlice';
import TileType from '../tile/enums/TileType';
import { AttackResult } from '../../models/AttackResult';

interface Props {
  isEnemy: boolean;
  attackResults: AttackResult[];
}

const Grid: React.FC<Props> = (props) => {
	const dispatch = useAppDispatch();

	// redux State
	const [attackResults, setAttackResults] = useState<AttackResult[]>([]);
	const selectedInventoryItem = useAppSelector((state) => state.inventory.selectedItem);
	const playerGrid = useAppSelector((state) => state.grid.playerGridItems);
	const enemyGrid = useAppSelector((state) => state.grid.enemyGridItems);

	// use effect
	useEffect(() => {
		updateAttackResults();
	}, [props.attackResults]);

	// methods

	function updateAttackResults ()
	{
		setAttackResults(props.attackResults);

		props.attackResults.forEach(x => setTimeout(function() { removeAttackResult(x.gridId); }, x.damage.time*1000));
	}

	function removeAttackResult(id: number)
	{	
		const newAttackResults: AttackResult[] = [];

		attackResults.forEach( (x) => {
			console.log(x.gridId);
			newAttackResults.push(x);
		});

	    setAttackResults(newAttackResults);
	}

	function onGridTileClick(id: number, tileType: TileType) {
		if(tileType == TileType.Placeholder){
			return;
		} 

		if (!selectedInventoryItem) {
			return;
		}

		dispatch(executePlaceCommand(id))
			.then(() => {
				dispatch(getPlayerGridItems());
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
						damage={attackResults.find(x => x.gridId==item.id)?.damage}
						item={item}
						isEnemy={props.isEnemy}
					/>
				))
				: playerGrid.map((item, index) => (
					<GridTile
						key={index}
						id={item.id}
						selectable={
							item.itemType != TileType.Placeholder
						}
						onTileClick={onGridTileClick}
						tileType={item.itemType}
						damage={attackResults.find(x => x.gridId==item.id)?.damage}
						item={item}
						isEnemy={props.isEnemy}
					/>
				))}
		</div>
	);
};

export default Grid;
