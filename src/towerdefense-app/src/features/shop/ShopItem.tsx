import React from 'react';
import TileType from '../tile/enums/TileType';
import Tile from '../tile/Tile';
import { useAppSelector } from '../../app/hooks';

interface Props{
    id: string
    onTileClick: (id: string) => void;
    tileType: TileType
}

const ShopItem: React.FC<Props> = (props) => {
	const selectedItem = useAppSelector((state) => state.shop.selectedItem);

    
	return (
		<div className={ selectedItem === props.id ? 'shop-item selected' : 'shop-item'} key={props.id.toString()} onClick={()=>props.onTileClick(props.id) }>
			<Tile tileType={props.tileType}></Tile>
		</div>
	);
};

export default ShopItem;


