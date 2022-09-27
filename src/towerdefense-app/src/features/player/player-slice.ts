import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { AddNewPlayerRequest } from '../../contracts/AddNewPlayerRequest';

interface Player {
    name:string
}

const initialState: Player = {
    name: "test1"
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
    baseUrl: 'https://localhost:7042/api/',
    prepareHeaders(headers) {
      return headers;
    },
  }),
  endpoints(builder) {
    return {
      addNewPlayer: builder.mutation({
        query: (payload: AddNewPlayerRequest) => ({
          url: '/players',
          method: 'POST',
          body: payload,
          headers: {
            'Content-type': 'application/json; charset=UTF-8',
          },
        }),
      }),
      endTurn: builder.mutation({
        query: (payload) => ({
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