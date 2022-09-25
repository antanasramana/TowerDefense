import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import {InventoryItem} from "../../types/InventoryItem";

interface Inventory {
    selectedItem: string,
    inventoryItems: InventoryItem[]
}

const initialState: Inventory = {
    selectedItem: "",
    inventoryItems: []
};

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
});


export const inventoryApiSlice = createApi({
    reducerPath: 'inventoryApi',
    baseQuery: fetchBaseQuery({
      baseUrl: 'https://localhost:7042/api/',
      prepareHeaders(headers) {
        return headers;
      },
    }),
    endpoints(builder) {
      return {
        getInventoryItems: builder.mutation({
          query: (payload) => ({
            url: '/inventory',
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


export const { useGetInventoryItemsMutation } = inventoryApiSlice;
export const { setSelectedItem, setInventoryItems } = inventorySlice.actions;
export default inventorySlice.reducer;