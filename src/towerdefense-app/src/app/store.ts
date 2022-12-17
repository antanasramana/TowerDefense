import { configureStore } from '@reduxjs/toolkit';
import playerReducer from '../features/player/PlayerSlice';
import enemyReducer from '../features/player/EnemySlice';
import shopReducer from '../features/shop/ShopSlice';
import inventoryReducer from '../features/inventory/InventorySlice';
import gridReducer from '../features/grid/GridSlice';
import perkStorageReducer from '../features/perks/PerkStorageSlice';
import storage from 'redux-persist/lib/storage';
import { persistReducer, persistStore } from 'redux-persist';

const persistConfig = {
	key: 'root',
	storage,
};

const persistedReducer = persistReducer(persistConfig, playerReducer);

export const store = configureStore({
	reducer: {
		player: persistedReducer,
		enemy: enemyReducer,
		shop: shopReducer,
		inventory: inventoryReducer,
		grid: gridReducer,
		perkStorage: perkStorageReducer
	},
	devTools: process.env.NODE_ENV !== 'production',
});

export const persistor = persistStore(store);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
