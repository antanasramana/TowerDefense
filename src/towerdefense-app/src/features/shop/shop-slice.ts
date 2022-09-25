import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import {ShopItem} from "../../types/ShopItem";

interface Shop {
    selectedItem: string
    shopItems: ShopItem[]
}

const initialState: Shop = {
    selectedItem: "",
    shopItems: [{id:"test",price:69, itemType:0 }]
};

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
        getShopItems: builder.mutation({
          query: () => ({
            url: '/shop',
            method: 'GET',
            headers: {
              'Content-type': 'application/json; charset=UTF-8',
            },
          }),
        }),
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
  
export const { useGetShopItemsMutation, useBuyShopItemMutation } = shopApiSlice;
export const { setSelectedItem, setShopItems } = shopSlice.actions;
export default shopSlice.reducer;