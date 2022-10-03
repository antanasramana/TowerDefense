import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { AddNewPlayerRequest } from '../../contracts/AddNewPlayerRequest';
import { AddNewPlayerResponse } from '../../contracts/AddNewPlayerResponse';
import { EndTurnRequest } from '../../contracts/EndTurnRequest';
import { EndTurnResponse } from '../../contracts/EndTurnResponse';
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

const playerSlice = createSlice({
	name: 'player',
	initialState,
	reducers: {
		setName(state, action: PayloadAction<string>) {
			state.name = action.payload;
		},
		setLevel(state, action: PayloadAction<Level>){
			state.level = action.payload;
		},
		setHealth(state, action: PayloadAction<number>){
			state.health = action.payload;
		},
		setArmor(state, action: PayloadAction<number>){
			state.armor = action.payload;
		},
		setMoney(state, action: PayloadAction<number>){
			state.money = action.payload;
		}
	},
});

export const apiSlice = createApi({
	reducerPath: 'api',
	baseQuery: fetchBaseQuery({
		baseUrl: API_URL,
		prepareHeaders(headers) {
			return headers;
		},
	}),
	endpoints(builder) {
		return {
			addNewPlayer: builder.mutation<AddNewPlayerResponse, AddNewPlayerRequest>({
				query: (payload: AddNewPlayerRequest) => ({
					url: '/players',
					method: 'POST',
					body: payload,
					headers: {
						'Content-type': 'application/json; charset=UTF-8',
					},
				}),
			}),
			endTurn: builder.mutation<EndTurnResponse, EndTurnRequest>({
				query: (payload: EndTurnRequest) => ({
					url: '/players/endturn',
					method: 'POST',
					body: payload,
					headers: {
						'Content-type': 'application/json; charset=UTF-8',
					},
				}),
			}),
		};
	},
});

export const { useAddNewPlayerMutation, useEndTurnMutation } = apiSlice;
export const { setName, setLevel, setHealth, setArmor, setMoney } = playerSlice.actions;
export default playerSlice.reducer;
