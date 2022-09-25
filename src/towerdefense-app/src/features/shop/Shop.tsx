import React, {useEffect} from 'react';
import Tile from '../tile/Tile'
import TileType from '../tile/enums/TileType'
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { useGetShopItemsMutation, useBuyShopItemMutation, setShopItems } from './shop-slice'
import { useGetInventoryItemsMutation, setInventoryItems } from '../inventory/inventory-slice'
import { setSelectedItem } from './shop-slice'

import './Shop.css';
import ShopItem from './ShopItem';

const Shop: React.FC = () => {
  const dispatch = useAppDispatch();

  const shopItems = useAppSelector((state) => state.shop.shopItems);
  const playerName = useAppSelector((state) => state.player.name);
  const selectedShopItem = useAppSelector((state) => state.shop.selectedItem);

  const [getShopItems, response] = useGetShopItemsMutation();
  const [buyShopItem, res] = useBuyShopItemMutation()
  const [getInventoryItems, r] = useGetInventoryItemsMutation()

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
      const getInventoryRequest ={
        playerName:playerName
      }
      getInventoryItems(getInventoryRequest)
      .unwrap()
      .then((res)=> {
        dispatch(setInventoryItems(res.items));
      });
    })
  }

  useEffect(() => {
    getShopItems("")
    .unwrap()
    .then((res) => {
        dispatch(setShopItems(res.items));
    }).catch((error) => {
      console.log(error)
    })
  }, []);

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
