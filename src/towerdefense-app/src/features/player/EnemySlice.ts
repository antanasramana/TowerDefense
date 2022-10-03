import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface Enemy {
  name: string;
  health: number;
  armor: number;
}

const initialState: Enemy = {
	name: 'Waiting ...',
	health: 100,
	armor: 100,
};

const enemySlice = createSlice({
	name: 'enemy',
	initialState,
	reducers: {
		setName(state, action: PayloadAction<string>) {
			state.name = action.payload;
		},
		setHealth(state, action: PayloadAction<number>){
			state.health = action.payload;
		},
		setArmor(state, action: PayloadAction<number>){
			state.armor = action.payload;
		},
	},
});

export const { setName, setHealth, setArmor } = enemySlice.actions;
export default enemySlice.reducer;
