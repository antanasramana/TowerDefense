import React, { useState } from 'react';
import { useAppDispatch } from '../../app/hooks';
import { setName, setLevel, setHealth, setArmor, setMoney, useAddNewPlayerMutation } from '../player/PlayerSlice';
import { useNavigate } from 'react-router-dom';
import './Home.css';
import { AddNewPlayerRequest } from '../../contracts/AddNewPlayerRequest';
import Level from '../player/enums/Levels';

const Home: React.FC = () => {
	const navigate = useNavigate();
	const dispatch = useAppDispatch();
	const [addNewPlayer] = useAddNewPlayerMutation();

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

		addNewPlayer(addNewPlayerRequest)
			.unwrap()
			.then((res) => {
				dispatch(setName(playerName));
				dispatch(setLevel(level));
				dispatch(setHealth(res.health));
				dispatch(setArmor(res.armor));
				dispatch(setMoney(res.money));
				navigate('/gamearena');
			})
			.catch((error) => {
				console.log(error);
			});
	}

	return (
		<div className='Home'>
			<div className='Home-welcome'>
				<h1 className='Home-header'>Tower Defense</h1>
				<input className='Home-name-input' onChange={(e) => handleNameChange(e.target.value)} />
				<div>      
					<label>
					Level
						<select onChange={(e) => {
							const level = parseInt(e.target.value);
							handleLevelChange(level);
						}}>
							<option value={Level.First}>First</option>
							<option value={Level.Second}>Second</option>
							<option value={Level.Third}>Third</option>
						</select>
					</label>
				</div>
				<br />
				<button className='Home-start-button' onClick={startGame} disabled={!playerName}>
          			Start game
				</button>
			</div>
		</div>
	);
};

export default Home;
