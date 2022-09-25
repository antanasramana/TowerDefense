import React from "react";
import Tile from "../tile/Tile"
import TileType from "../tile/enums/TileType";
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { useAddGridItemMutation, setEnemyGridItems, setPlayerGridItems } from './grid-slice'
import { setInventoryItems } from '../inventory/inventory-slice'
import "./Grid.css"
import GridTile from "./GridTile";

interface Props{
    isEnemy: boolean
}

const Grid: React.FC<Props> = (props) => {

    const dispatch = useAppDispatch();

    const selectedInventoryItem = useAppSelector((state) => state.inventory.selectedItem);
    const playerName = useAppSelector((state) => state.player.name);
    const playerGrid = useAppSelector((state) => state.grid.playerGridItems);
    const enemyGrid = useAppSelector((state) => state.grid.enemyGridItems);

    const [addGridItem, response] = useAddGridItemMutation();

    function onGridTileClick(id: number)
    {
        if (!selectedInventoryItem)
        {
            console.log("No selected item!");
            return;
        }
        // TODO: add to contracts
        const addGridItemRequest = {
            playerName: playerName,
            inventoryItemId: selectedInventoryItem,
            gridItemId: id
        }

        addGridItem(addGridItemRequest)
        .unwrap()
        .then( res => {
            console.log(res);
            dispatch(setInventoryItems(res.items));
            dispatch(setPlayerGridItems(res.gridItems));
        });
    }

    return (
        <div className={props.isEnemy ? "grid enemy" : "grid"}>
            {props.isEnemy?
             enemyGrid.map( i => <GridTile id={i.id} selectable={!props.isEnemy} onTileClick={()=>{}} tileType={i.itemType}/>)
             :
             playerGrid.map( i => <GridTile id={i.id} selectable={!props.isEnemy} onTileClick={onGridTileClick } tileType={i.itemType}/>)
            }       
        </div>
    );
}

export default Grid;

