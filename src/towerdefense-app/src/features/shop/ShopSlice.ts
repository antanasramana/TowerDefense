import axios from 'axios';
import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { ShopItem } from '../../models/ShopItem';
import { store } from '../../app/store';
import { BuyShopItemRequest } from '../../contracts/BuyShopItemRequest';
const API_URL = process.env.REACT_APP_BACKEND;

interface Shop {
  selectedItem: string;
  shopItems: ShopItem[];
}

const initialState: Shop = {
	selectedItem: '',
	shopItems: [],
};

export const getShopItems = createAsyncThunk<ShopItem[]>('shop/getShop', async () => {
	const reduxStore = store.getState();
	const response = await axios.get(`${API_URL}/shop/${reduxStore.player.name}`);
	return response.data.items;
});

const shopSlice = createSlice({
	name: 'shop',
	initialState,
	reducers: {
		setShopToInitial(state, action: PayloadAction) {
			state.selectedItem = initialState.selectedItem;
			state.shopItems = initialState.shopItems;
		},
		setSelectedItem(state, action: PayloadAction<string>) {
			state.selectedItem = action.payload;
		},
		setShopItems(state, action: PayloadAction<ShopItem[]>) {
			state.shopItems = action.payload;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(getShopItems.fulfilled, (state, action: PayloadAction<ShopItem[]>) => {
			state.shopItems = action.payload;
		});
		builder.addCase(getShopItems.rejected, () => {
			console.error('Failed to get shop from api!');
		});
	},
});

export const shopApiSlice = createApi({
	reducerPath: 'shopApi',
	baseQuery: fetchBaseQuery({
		baseUrl: API_URL,
		prepareHeaders(headers) {
			return headers;
		},
	}),
	endpoints(builder) {
		return {
			buyShopItem: builder.mutation<string, BuyShopItemRequest>({
				query: (payload: BuyShopItemRequest) => ({
					url: '/shop',
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

export const { useBuyShopItemMutation } = shopApiSlice;
export const { setSelectedItem, setShopItems, setShopToInitial } = shopSlice.actions;
export default shopSlice.reducer;
