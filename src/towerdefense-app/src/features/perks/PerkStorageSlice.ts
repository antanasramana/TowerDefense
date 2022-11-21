import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/dist/query/react';
import axios from 'axios';
import { store } from '../../app/store';
import { ApplyPerkRequest } from '../../contracts/ApplyPerkRequest';
import { GetPerksResponse } from '../../contracts/GetPerkResponse';
import { Perk } from './types/Perk';
const API_URL = process.env.REACT_APP_BACKEND;

interface PerkStorage {
    perks: Perk[];
}

const initialState: PerkStorage = {
	perks: new Array<Perk>()
};

export const getPerks = createAsyncThunk<GetPerksResponse>('perks/getPerks', async () => {
	const reduxStore = store.getState();
	const response = await axios.get<GetPerksResponse>(`${API_URL}/perks/${reduxStore.player.name}`);
	return response.data;
});

const perksSlice = createSlice({
	name: 'perks',
	initialState,
	reducers: {
		setPerks(state, action: PayloadAction<Perk[]>) {
			state.perks = action.payload;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(getPerks.fulfilled, (state, action: PayloadAction<GetPerksResponse>) => {
			state.perks = action.payload.perks;
		});
		builder.addCase(getPerks.rejected, () => {
			console.error('Failed to get perks from api!');
		});
	},
});


export const perksApiSlice = createApi({
	reducerPath: 'perksApi',
	baseQuery: fetchBaseQuery({
		baseUrl: API_URL,
		prepareHeaders(headers) {
			return headers;
		},
	}),
	endpoints(builder) {
		return {
			applyPerk: builder.mutation<string, ApplyPerkRequest>({
				query: (payload: ApplyPerkRequest) => ({
					url: '/perks',
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

export const { useApplyPerkMutation } = perksApiSlice;

export const { setPerks } = perksSlice.actions;
export default perksSlice.reducer;
