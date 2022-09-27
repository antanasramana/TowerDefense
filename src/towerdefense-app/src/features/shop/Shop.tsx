import React, {useEffect} from 'react';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { useBuyShopItemMutation, getShopItems } from './shop-slice'
import { getInventoryItems } from '../inventory/inventory-slice'
import { setSelectedItem } from './shop-slice'

import './Shop.css';
import ShopItem from './ShopItem';

const Shop: React.FC = () => {
  const dispatch = useAppDispatch();

  const shopItems = useAppSelector((state) => state.shop.shopItems);
  const playerName = useAppSelector((state) => state.player.name);
  const selectedShopItem = useAppSelector((state) => state.shop.selectedItem);

  const [buyShopItem] = useBuyShopItemMutation();

  function onShopItemClick(id:string)
  {
    dispatch(setSelectedItem(id));
  }

  function onBuyItem()
  {
    let formData = {
      itemId: selectedShopItem,
      playerName: playerName,
    };

    buyShopItem(formData)
    .unwrap()
    .then(()=>{
      dispatch(getInventoryItems());      
    })
  }

  useEffect(() => {
    dispatch(getShopItems());
  }, [dispatch]);

  return (
    <div>
        <h3 className="shop-header">SHOP</h3>
        <div className="shop-container">
          <div className="shop-item-container">
            {shopItems.map((i)=> <ShopItem id ={i.id} onTileClick={onShopItemClick} tileType={i.itemType}/>)}
          </div>
          <div>
            <button className="shop-button" onClick={onBuyItem}>Buy</button>
          </div>
        </div>
    </div>
  );
}

export default Shop;
