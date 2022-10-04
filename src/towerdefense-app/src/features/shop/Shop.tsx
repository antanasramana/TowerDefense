import React, { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { useBuyShopItemMutation, getShopItems } from './ShopSlice';
import { getInventoryItems } from '../inventory/InventorySlice';
import { setSelectedItem } from './ShopSlice';

import './Shop.css';
import ShopItem from './ShopItem';
import { BuyShopItemRequest } from '../../contracts/BuyShopItemRequest';
import { getPlayerInfo } from '../player/PlayerSlice';

const Shop: React.FC = () => {
	const dispatch = useAppDispatch();

	const shopItems = useAppSelector((state) => state.shop.shopItems);
	const playerName = useAppSelector((state) => state.player.name);
	const selectedShopItem = useAppSelector((state) => state.shop.selectedItem);

	const [buyShopItem] = useBuyShopItemMutation();

	function onShopItemClick(id: string) {
		dispatch(setSelectedItem(id));
	}

	function onBuyItem() {
		const buyShopItemRequest : BuyShopItemRequest = {
			itemId: selectedShopItem,
			playerName: playerName,
		};

		buyShopItem(buyShopItemRequest)
			.unwrap()
			.then(() => {
				dispatch(getInventoryItems());
				dispatch(getPlayerInfo());
			});
	}

	useEffect(() => {
		dispatch(getShopItems());
	}, [dispatch]);

	return (
		<div>
			<h3 className='shop-header'>SHOP</h3>
			<div className='shop-container'>
				<div className='shop-item-container'>
					{shopItems.map((item, index) => (
						<ShopItem
							key={index}
							id={item.id}
							onTileClick={onShopItemClick}
							tileType={item.itemType}
						/>
					))}
				</div>
				<div>
					<button className='shop-button' onClick={onBuyItem}>
            Buy
					</button>
				</div>
			</div>
		</div>
	);
};

export default Shop;
