import React from 'react';
import TileType from '../tile/enums/TileType';
import Tile from '../tile/Tile';

interface Props {
  id: number;
  onTileClick: (id: number) => void;
  tileType: TileType;
  selectable: boolean;
}

const GridTile: React.FC<Props> = (props) => {
	return (
		<div
			className={props.selectable ? 'grid-item' : 'grid-item-enemy'}
			key={props.id.toString()}
			onClick={() => props.onTileClick(props.id)}
		>
			<Tile tileType={props.tileType}></Tile>
		</div>
	);
};

export default GridTile;
