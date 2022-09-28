import React, { useEffect } from 'react';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import Home from './features/home/Home';
import GameArena from './features/game-arena/GameArena';

const App: React.FC = () => {
	useEffect(() => {
		document.title = 'Tower Defense';
	}, []);

	return (
		<BrowserRouter>
			<Routes>
				<Route index element={<Home />} />
				<Route path="gamearena" element={<GameArena/>} />
			</Routes>
		</BrowserRouter>
	);
};

export default App;
