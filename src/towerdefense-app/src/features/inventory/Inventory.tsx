import React from 'react';
import Tile from '../tile/Tile';
import TileType from '../tile/enums/TileType';

import './Inventory.css';

const Inventory: React.FC = () => {
  return (
    <div className="inventory-container">
        <div className="inventory-header">INVENTORY</div>
        <div className="inventory-item-container">
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Shield}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
        </div>
    </div>
  );
}

export default Inventory;
