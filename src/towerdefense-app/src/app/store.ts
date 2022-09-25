import { configureStore } from '@reduxjs/toolkit';
import playerReducer from '../features/player/player-slice';
import enemyReducer from '../features/player/enemy-slice';
import { apiSlice } from '../features/player/player-slice';
import storage from 'redux-persist/lib/storage';
import { persistReducer, persistStore } from 'redux-persist';
import thunk from 'redux-thunk';

const persistConfig = {
    key: 'root',
    storage,
}

const persistedReducer = persistReducer(persistConfig, playerReducer)

export const store = configureStore({
    reducer: {
        player: persistedReducer,
        enemy: enemyReducer, 
        [apiSlice.reducerPath]: apiSlice.reducer,
    },
    devTools: process.env.NODE_ENV !== 'production',
    middleware: [thunk]
})

export const persistor = persistStore(store)

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;