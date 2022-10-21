import React from 'react';
import { Damage } from '../../models/Damage';
import DamageOverlay from '../damage/DamageOverlay';
import TileType from '../tile/enums/TileType';
import Tile from '../tile/Tile';
import { setSelectedGridItemId } from './GridSlice';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { GridItem } from '../../models/GridItem';
import './Grid.css';
interface Props {
  id: number;
  onTileClick: (id: number, tileType: TileType) => void;
  tileType: TileType;
  selectable: boolean;
  damage: Damage| undefined;
  item: GridItem
}

const GridTile: React.FC<Props> = (props) => {
	const dispatch = useAppDispatch();
	const selectedGridItemId = useAppSelector((state) => state.grid.selectedGridItemId);

	function onGridItemClick() {
		dispatch(setSelectedGridItemId(-1));
		if (props.id == selectedGridItemId) {
			return;
		}
		if (props.tileType == TileType.Blank || props.tileType == TileType.Placeholder) {
			props.onTileClick(props.id, props.tileType);
			return;
		}
		dispatch(setSelectedGridItemId(props.id));
	}

	function gridTileStyle(): string {
		if (props.id === selectedGridItemId) {
			return 'grid-item selected';
		}
		return 'grid-item';
	}

	return (
		<div
			className={props.selectable ? gridTileStyle() : 'grid-item-enemy'}
			key={props.id.toString()}
			onClick={onGridItemClick}
		>
			<Tile tileType={props.tileType}></Tile>
			{  props.damage != undefined && <DamageOverlay damage={props.damage}></DamageOverlay> }
			{ props.item.level != 0 && <h6 className='item-level'>{props.item.level}</h6> }
		</div>
	);
};

export default GridTile;
