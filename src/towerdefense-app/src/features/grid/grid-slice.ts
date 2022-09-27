import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { AddGridItemRequest } from '../../contracts/AddGridItemRequest';
import {GridItem} from "../../models/GridItem";
const API_URL = process.env.REACT_APP_BACKEND;

interface Grid {
    playerGridItems: GridItem[],
    enemyGridItems: GridItem[]
}

const initialState: Grid = {
    playerGridItems: Array.from(Array(72).keys()).map<GridItem>(i => ({id:i, itemType:3 })),
    enemyGridItems: Array.from(Array(72).keys()).map<GridItem>(i => ({id:i, itemType:2 }))
};

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
        addGridItem: builder.mutation({
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