import React from "react";
import TileType from "../tile/enums/TileType";
import Tile from '../tile/Tile'
import { useAppDispatch, useAppSelector } from '../../app/hooks';

interface Props{
    id: string
    onTileClick: (id: string) => void;
    tileType: TileType
}

const InventoryTile: React.FC<Props> = (props) => {
    const selectedItem = useAppSelector((state) => state.inventory.selectedItem);

    return (
        <div className={selectedItem==props.id ? "inventory-item selected" : "inventory-item"} key={props.id.toString()} onClick={()=>props.onTileClick(props.id)}>
            <Tile tileType={props.tileType}></Tile>
        </div>
    );
}

export default InventoryTile;
