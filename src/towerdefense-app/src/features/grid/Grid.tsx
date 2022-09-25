import React from "react";
import Tile from "../tile/Tile"
import TileType from "../tile/enums/TileType";

import "./Grid.css"

const Grid: React.FC = () => {
    const tiles = [];
    for(let i = 0; i < 72; i++){
        tiles.push(<Tile tileType={TileType.Placeholder}/>)
    }
    return (
        <div className="grid">
            {tiles}       
        </div>
    );
}

export default Grid;

