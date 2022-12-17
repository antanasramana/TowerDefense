import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import axios from 'axios';
import { store } from '../../app/store';
import { AddNewPlayerRequest } from '../../contracts/AddNewPlayerRequest';
import { AddNewPlayerResponse } from '../../contracts/AddNewPlayerResponse';
import { EndTurnRequest } from '../../contracts/EndTurnRequest';
import { EndTurnResponse } from '../../contracts/EndTurnResponse';
import { GetPlayerInfoResponse } from '../../contracts/GetPlayerInfoResponse';
import Level from './enums/Levels';

const API_URL = process.env.REACT_APP_BACKEND;

interface Player {
  name: string;
  level: Level;
  health: number;
  armor: number;
  money: number;
}

const initialState: Player = {
	name: 'test1',
	level: Level.First,
	health: 100,
	armor: 100,
	money: 1000
};

export const getPlayerInfo = createAsyncThunk<GetPlayerInfoResponse>('player/getPlayerInfo', async () => {
	const reduxStore = store.getState();
	const response = await axios.get<GetPlayerInfoResponse>(`${API_URL}/players/${reduxStore.player.name}`);
	return response.data;
});

export const addNewPlayer = createAsyncThunk<AddNewPlayerResponse, AddNewPlayerRequest>('player/addNewPlayer', async (addNewPlayerRequest: AddNewPlayerRequest) => {
	const response = await axios.post<AddNewPlayerResponse>(`${API_URL}/players`, addNewPlayerRequest );
	return response.data;
});

export const endTurn = createAsyncThunk<EndTurnResponse, EndTurnRequest>('player/endTurn', async (endTurnRequest: EndTurnRequest) => {
	const response = await axios.post<EndTurnResponse>(`${API_URL}/players/endturn`, endTurnRequest);
	return response.data;
});

const playerSlice = createSlice({
	name: 'player',
	initialState,
	reducers: {
		setPlayerToInitial(state, action: PayloadAction) {
			state.name = initialState.name;
			state.level = initialState.level;
			state.health = initialState.health;
			state.armor = initialState.armor;
			state.money = initialState.money;
		},
		setPlayer(state, action: PayloadAction<Player>) {
			state.name = action.payload.name;
			state.health = action.payload.health;
			state.armor = action.payload.armor;
			state.money = action.payload.money;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(getPlayerInfo.fulfilled, (state, action: PayloadAction<GetPlayerInfoResponse>) => {
			state.name = action.payload.playerName;
			state.armor = action.payload.armor;
			state.health = action.payload.health;
			state.money = action.payload.money;
		});

		builder.addCase(addNewPlayer.fulfilled, (state, action: PayloadAction<AddNewPlayerResponse>) => {
			state.name = action.payload.playerName;
			state.armor = action.payload.armor;
			state.health = action.payload.health;
			state.money = action.payload.money;
		});
	},
});

export const { setPlayer, setPlayerToInitial } = playerSlice.actions;
export default playerSlice.reducer;
