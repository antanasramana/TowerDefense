import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { AddGridItemRequest } from '../../contracts/AddGridItemRequest';
import { AddGridItemResponse } from '../../contracts/AddGridItemResponse';
import { store } from '../../app/store';
import { GridItem } from '../../models/GridItem';
import TileType from '../tile/enums/TileType';
import { ExecuteCommandRequest } from '../../contracts/ExecuteCommandRequest';
import CommandType from '../../models/CommandType';
import { InterpretCommandRequest } from '../../contracts/InterpretCommandRequest';
const API_URL = process.env.REACT_APP_BACKEND;

interface Grid {
  playerGridItems: GridItem[];
  enemyGridItems: GridItem[];
  selectedGridItemId: number;
}

const initialState: Grid = {
	playerGridItems: Array.from(Array(72).keys()).map<GridItem>((index) => ({ id: index, itemType: TileType.Blank, level: 0, damage: 0, health: 0, powerUps: [] })),
	enemyGridItems: Array.from(Array(72).keys()).map<GridItem>((index) => ({ id: index, itemType: TileType.Placeholder, level: 0, damage: 0, health: 0, powerUps: [] })),
	selectedGridItemId: -1
};

// TODO - ADD CONTRACTS
// TODO - make it parametrized
export const interpretCommand = createAsyncThunk('grid/command', async (commandtext: string) => {
	const reduxStore = store.getState();
	const interpretCommandRequest: InterpretCommandRequest = {
		playerName: reduxStore.player.name,
		commandText: commandtext,
	};
	await axios.post(`${API_URL}/grid/command/text`, interpretCommandRequest);
});

export const executeCommand = createAsyncThunk('grid/command', async (commandType: CommandType) => {
	const reduxStore = store.getState();
	const executeCommandRequest: ExecuteCommandRequest = {
		playerName: reduxStore.player.name,
		shopItemId: reduxStore.shop.selectedItem,
		gridItemId: reduxStore.grid.selectedGridItemId,
		inventoryItemId: reduxStore.inventory.selectedItem,
		commandType: commandType
	};
	await axios.post(`${API_URL}/grid/command`, executeCommandRequest);
});

export const executePlaceCommand = createAsyncThunk('grid/command', async (selectedGridItemId: number) => {
	const reduxStore = store.getState();
	const executeCommandRequest: ExecuteCommandRequest = {
		playerName: reduxStore.player.name,
		shopItemId: reduxStore.shop.selectedItem,
		gridItemId: selectedGridItemId,
		inventoryItemId: reduxStore.inventory.selectedItem,
		commandType: CommandType.Place
	};
	await axios.post(`${API_URL}/grid/command`, executeCommandRequest);
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
		setGridToInitial(state, action: PayloadAction) {
			state.playerGridItems = initialState.playerGridItems;
			state.enemyGridItems = initialState.enemyGridItems;
			state.selectedGridItemId = initialState.selectedGridItemId;
		},
		setPlayerGridItems(state, action: PayloadAction<GridItem[]>) {
			state.playerGridItems = action.payload;
		},
		setEnemyGridItems(state, action: PayloadAction<GridItem[]>) {
			state.enemyGridItems = action.payload;
		},
		setSelectedGridItemId(state, action: PayloadAction<number>) {
			state.selectedGridItemId = action.payload;
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
export const { setEnemyGridItems, setPlayerGridItems, setSelectedGridItemId, setGridToInitial } = gridSlice.actions;
export default gridSlice.reducer;
