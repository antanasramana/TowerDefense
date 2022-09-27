import React from 'react';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { setSelectedItem } from './inventory-slice'
import './Inventory.css';
import InventoryTile from './InventoryTile';

const Inventory: React.FC = () => {

  const dispatch = useAppDispatch();
  const inventoryItems = useAppSelector((state) => state.inventory.inventoryItems);

  function onShopItemClick(id:string)
  {
    dispatch(setSelectedItem(id));
  }

  return (
    <div className="inventory-container">
        <div className="inventory-header">INVENTORY</div>
        <div className="inventory-item-container">
           {inventoryItems.map((item, index)=> <InventoryTile key={index} id ={item.id} onTileClick={onShopItemClick} tileType={item.itemType}/>)}     
        </div>
    </div>
  );
}

export default Inventory;
