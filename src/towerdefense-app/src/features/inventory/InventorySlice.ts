import axios from 'axios';
import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit';
import { store } from '../../app/store';
import { InventoryItem } from '../../models/InventoryItem';
const API_URL = process.env.REACT_APP_BACKEND;

interface Inventory {
  selectedItem: string;
  inventoryItems: InventoryItem[];
}

const initialState: Inventory = {
	selectedItem: '',
	inventoryItems: [],
};

export const getInventoryItems = createAsyncThunk<InventoryItem[]>('inventory/getInventory', async () => {
	const reduxStore = store.getState();
	const response = await axios.get(`${API_URL}/inventory/${reduxStore.player.name}`);
	return response.data.items;
});

const inventorySlice = createSlice({
	name: 'inventory',
	initialState,
	reducers: {
		setSelectedItem(state, action: PayloadAction<string>) {
			state.selectedItem = action.payload;
		},
		setInventoryItems(state, action: PayloadAction<InventoryItem[]>) {
			state.inventoryItems = action.payload;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(getInventoryItems.fulfilled,
			(state, action: PayloadAction<InventoryItem[]>) => {
				state.inventoryItems = action.payload;
			},);
		builder.addCase(getInventoryItems.rejected, () => {
			console.error('Failed to get inventory from api!');
		});
	},
});

export const { setSelectedItem, setInventoryItems } = inventorySlice.actions;
export default inventorySlice.reducer;
