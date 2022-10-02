import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { AddNewPlayerRequest } from '../../contracts/AddNewPlayerRequest';
import { AddNewPlayerResponse } from '../../contracts/AddNewPlayerResponse';
import { EndTurnRequest } from '../../contracts/EndTurnRequest';
import { EndTurnResponse } from '../../contracts/EndTurnResponse';
const API_URL = process.env.REACT_APP_BACKEND;

interface Player {
  name: string;
}

const initialState: Player = {
	name: 'test1',
};

const playerSlice = createSlice({
	name: 'player',
	initialState,
	reducers: {
		setName(state, action: PayloadAction<string>) {
			state.name = action.payload;
		},
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
export const { setName } = playerSlice.actions;
export default playerSlice.reducer;