import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { AddGridItemRequest } from '../../contracts/AddGridItemRequest';
import { AddGridItemResponse } from '../../contracts/AddGridItemResponse';
import { store } from '../../app/store';
import { GridItem } from '../../models/GridItem';
import TileType from '../tile/enums/TileType';
const API_URL = process.env.REACT_APP_BACKEND;

interface Grid {
  playerGridItems: GridItem[];
  enemyGridItems: GridItem[];
}

const initialState: Grid = {
	playerGridItems: Array.from(Array(72).keys()).map<GridItem>((index) => ({ id: index, itemType: TileType.Blank })),
	enemyGridItems: Array.from(Array(72).keys()).map<GridItem>((index) => ({ id: index, itemType: TileType.Placeholder })),
};

// TODO - ADD CONTRACTS
// TODO - make it parametrized

export const upgradeRockets = createAsyncThunk('grid/upgradeRockets', async () => {
	await axios.post(`${API_URL}/grid/upgradeRockets`);
});


export const getPlayerGridItems = createAsyncThunk<GridItem[]>('grid/getPlayerGrid', async () => {
	const reduxStore = store.getState();
	const response = await axios.get(`${API_URL}/grid/${reduxStore.player.name}`);
	return response.data.gridItems;
});

export const getEnemyGridItems = createAsyncThunk<GridItem[]>('grid/getEnemyGrid', async () => {
	const reduxStore = store.getState();
	const response = await axios.get(`${API_URL}/grid/${reduxStore.enemy.name}`);
	return response.data.gridItems;
});


const gridSlice = createSlice({
	name: 'playerGrid',
	initialState,
	reducers: {
		setPlayerGridItems(state, action: PayloadAction<GridItem[]>) {
			state.playerGridItems = action.payload;
		},
		setEnemyGridItems(state, action: PayloadAction<GridItem[]>) {
			state.enemyGridItems = action.payload;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(getPlayerGridItems.fulfilled, (state, action: PayloadAction<GridItem[]>) => {
			state.playerGridItems = action.payload;
		});
		builder.addCase(getPlayerGridItems.rejected, () => {
			console.error('Failed to get player grid from api!');
		});
		builder.addCase(getEnemyGridItems.fulfilled, (state, action: PayloadAction<GridItem[]>) => {
			state.enemyGridItems = action.payload;
		});
		builder.addCase(getEnemyGridItems.rejected, () => {
			console.error('Failed to get enemy player grid from api!');
		});
	},
});

export const gridApiSlice = createApi({
	reducerPath: 'gridApi',
	baseQuery: fetchBaseQuery({
		baseUrl: API_URL,
		prepareHeaders(headers) {
			return headers;
		},
	}),
	endpoints(builder) {
		return {
			addGridItem: builder.mutation<AddGridItemResponse, AddGridItemRequest>({
				query: (payload: AddGridItemRequest) => ({
					url: '/grid/add',
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

export const { useAddGridItemMutation } = gridApiSlice;
export const { setEnemyGridItems, setPlayerGridItems } = gridSlice.actions;
export default gridSlice.reducer;
