import React from "react";
import "./Tile.css"
import TileType from "./enums/TileType";
import TileImage from "./mappings/TileImage"

interface Props{
    tileType: TileType
}

const Tile: React.FC<Props> = (props) => {
    const imageSource = TileImage.sourceMap.get(props.tileType)
    
    return (
        <div className="tile" style={{
            backgroundImage: `url(${imageSource})`
        }}/>
    );
}

export default Tile;


