import axios from 'axios';
import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { ShopItem } from "../../models/ShopItem";
const API_URL = process.env.REACT_APP_BACKEND;

interface Shop {
    selectedItem: string
    shopItems: ShopItem[]
}

const initialState: Shop = {
    selectedItem: "",
    shopItems: [{id:"test",price:69, itemType:0 }]
};

export const getShopItems = createAsyncThunk(
  'shop/getShop',  
  async () => {
    const response = await axios.get(`${API_URL}/shop`);
    return response.data.items;
})

const shopSlice = createSlice({
  name: 'shop',
  initialState,
  reducers: {
    setSelectedItem(state, action: PayloadAction<string>) {
      state.selectedItem = action.payload;
    },
    setShopItems(state, action: PayloadAction<ShopItem[]>) {
        state.shopItems = action.payload;
    },
  },
  extraReducers: builder => {
    builder.addCase(getShopItems.fulfilled,
      (state, action: PayloadAction<ShopItem[]>) => {
        state.shopItems = action.payload;
      }
    )
    builder.addCase(getShopItems.rejected, _ => {
      console.error("Failed to get shop from api!");
    })
  }
});

export const shopApiSlice = createApi({
    reducerPath: 'shopApi',
    baseQuery: fetchBaseQuery({
      baseUrl: 'https://localhost:7042/api/',
      prepareHeaders(headers) {
        return headers;
      },
    }),
    endpoints(builder) {
      return {
        buyShopItem: builder.mutation({
            query: (payload) => ({
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
export const { setSelectedItem, setShopItems } = shopSlice.actions;
export default shopSlice.reducer;