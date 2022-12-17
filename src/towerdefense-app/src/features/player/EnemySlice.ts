import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';
import { store } from '../../app/store';
import { GetPlayerInfoResponse } from '../../contracts/GetPlayerInfoResponse';
const API_URL = process.env.REACT_APP_BACKEND;

interface Enemy {
  name: string;
  health: number;
  armor: number;
  money: number;
}

const initialState: Enemy = {
	name: 'Waiting ...',
	health: 100,
	armor: 100,
	money: 1000
};

export const getEnemyInfo = createAsyncThunk<GetPlayerInfoResponse>('enemy/getPlayerInfo', async () => {
	const reduxStore = store.getState();
	const response = await axios.get<GetPlayerInfoResponse>(`${API_URL}/players/${reduxStore.enemy.name}`);
	console.log(response.data);
	return response.data;
});

const enemySlice = createSlice({
	name: 'enemy',
	initialState,
	reducers: {
		setEnemyToInitial(state, action: PayloadAction) {
			state.name = initialState.name;
			state.health = initialState.health;
			state.armor = initialState.armor;
			state.money = initialState.money;
		},
		setEnemyName(state, action: PayloadAction<string>) {
			state.name = action.payload;
		}
	},
	extraReducers: (builder) => {
		builder.addCase(getEnemyInfo.fulfilled, (state, action: PayloadAction<GetPlayerInfoResponse>) => {
			state.armor = action.payload.armor;
			state.health = action.payload.health;
			state.money = action.payload.money;
		});
		builder.addCase(getEnemyInfo.rejected, () => {
			console.error('Failed to get enemy info from api!');
		});
	},
});

export const { setEnemyName, setEnemyToInitial } = enemySlice.actions;
export default enemySlice.reducer;
