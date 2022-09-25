import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface Enemy {
    name:string
}

const initialState: Enemy = {
    name: "Waiting ..."
};

const playerSlice = createSlice({
  name: 'enemy',
  initialState,
  reducers: {
    setName(state, action: PayloadAction<string>) {
      state.name = action.payload;
    },
  },
});

export const { setName } = playerSlice.actions;
export default playerSlice.reducer;