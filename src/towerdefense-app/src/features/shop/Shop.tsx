import React from 'react';
import Tile from '../tile/Tile'
import TileType from '../tile/enums/TileType'

import './Shop.css';

const Shop: React.FC = () => {
  return (
    <div className="shop-container">
        <div className="shop-header">SHOP</div>
        <div className="shop-item-container">
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
            <Tile tileType={TileType.Rockets}/>
        </div>
    </div>
  );
}

export default Shop;
