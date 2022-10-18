import React from 'react';
import { Damage } from '../../models/Damage';
import DamageOverlay from '../damage/DamageOverlay';
import TileType from '../tile/enums/TileType';
import Tile from '../tile/Tile';

interface Props {
  id: number;
  onTileClick: (id: number, tileType: TileType) => void;
  tileType: TileType;
  selectable: boolean;
  damage: Damage| undefined;
}

const GridTile: React.FC<Props> = (props) => {
	return (
		<div
			className={props.selectable ? 'grid-item' : 'grid-item-enemy'}
			key={props.id.toString()}
			onClick={() => props.onTileClick(props.id, props.tileType)}
		>
			<Tile tileType={props.tileType}></Tile>
			{ props.damage != undefined && <DamageOverlay damage={props.damage}></DamageOverlay> }
		</div>
	);
};

export default GridTile;
