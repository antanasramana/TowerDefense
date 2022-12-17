import React, { useState } from 'react';
import { useAppDispatch } from '../../app/hooks';
import { addNewPlayer } from '../player/PlayerSlice';
import { useNavigate } from 'react-router-dom';
import './Home.css';
import { AddNewPlayerRequest } from '../../contracts/AddNewPlayerRequest';
import Level from '../player/enums/Levels';

const Home: React.FC = () => {
	const navigate = useNavigate();
	const dispatch = useAppDispatch();

	const [playerName, setPlayerName] = useState<string>('');
	const [level, setGameLevel] = useState<Level>(Level.First);

	function handleNameChange(name: string) {
		setPlayerName(name);
	}

	function handleLevelChange(level: Level){
		setGameLevel(level);
	}

	function startGame() {
		const addNewPlayerRequest: AddNewPlayerRequest = {
			playerName: playerName,
			level: level
		};
		
		dispatch(addNewPlayer(addNewPlayerRequest)).then( () => navigate('/game-arena'));
	}

	return (
		<div className='Home'>
			<div className='Home-welcome'>
				<h1 className='Home-header'>Tower Defense</h1>
				<input className='Home-name-input' onChange={(e) => handleNameChange(e.target.value)} />
				<br />
				<button className='Home-start-button' onClick={startGame} disabled={!playerName}>
          			Start game
				</button>
			</div>
		</div>
	);
};

export default Home;
