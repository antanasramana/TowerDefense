import { configureStore } from '@reduxjs/toolkit';
import playerReducer from '../features/player/player-slice';
import enemyReducer from '../features/player/enemy-slice';
import shopReducer from '../features/shop/shop-slice';
import inventoryReducer from '../features/inventory/inventory-slice';
import gridReducer from '../features/grid/grid-slice';
import { apiSlice } from '../features/player/player-slice';
import {shopApiSlice} from '../features/shop/shop-slice';
import {gridApiSlice} from '../features/grid/grid-slice';
import storage from 'redux-persist/lib/storage';
import { persistReducer, persistStore } from 'redux-persist';
import thunkMiddleware from 'redux-thunk';

const persistConfig = {
    key: 'root',
    storage,
}

const persistedReducer = persistReducer(persistConfig, playerReducer)

export const store = configureStore({
    reducer: {
        player: persistedReducer,
        enemy: enemyReducer, 
        shop: shopReducer, 
        inventory: inventoryReducer,
        grid:  gridReducer,
        [apiSlice.reducerPath]: apiSlice.reducer,
        [shopApiSlice.reducerPath]: shopApiSlice.reducer,
        [gridApiSlice.reducerPath]: gridApiSlice.reducer,
    },
    devTools: process.env.NODE_ENV !== 'production',
})

export const persistor = persistStore(store)

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;

