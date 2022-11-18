import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';
import { store } from '../../app/store';
import { GetPlayerInfoResponse } from '../../contracts/GetPlayerInfoResponse';
const API_URL = process.env.REACT_APP_BACKEND;

interface Enemy {
  name: string;
  health: number;
  armor: number;
}

const initialState: Enemy = {
	name: 'Waiting ...',
	health: 100,
	armor: 100,
};

export const getEnemyInfo = createAsyncThunk<GetPlayerInfoResponse>('player/getPlayerInfo', async () => {
	const reduxStore = store.getState();
	const response = await axios.get<GetPlayerInfoResponse>(`${API_URL}/players/${reduxStore.enemy.name}`);
	console.log(response.data);
	return response.data;
});

const enemySlice = createSlice({
	name: 'enemy',
	initialState,
	reducers: {
		setName(state, action: PayloadAction<string>) {
			state.name = action.payload;
		},
		setHealth(state, action: PayloadAction<number>){
			state.health = action.payload;
		},
		setArmor(state, action: PayloadAction<number>){
			state.armor = action.payload;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(getEnemyInfo.fulfilled, (state, action: PayloadAction<GetPlayerInfoResponse>) => {
			state.armor = action.payload.armor;
			state.health = action.payload.health;
		});
		builder.addCase(getEnemyInfo.rejected, () => {
			console.error('Failed to get enemy info from api!');
		});
	},
});

export const { setName, setHealth, setArmor } = enemySlice.actions;
export default enemySlice.reducer;
