import React, { useState } from 'react';
import { useAppDispatch } from '../../app/hooks';
import { setName, setLevel, setHealth, setArmor, setMoney, useAddNewPlayerMutation } from '../player/PlayerSlice';
import { useNavigate } from 'react-router-dom';
import './Home.css';
import { AddNewPlayerRequest } from '../../contracts/AddNewPlayerRequest';
import Level from '../player/enums/Levels';
import {useLocation} from 'react-router-dom';

const EndGame: React.FC = () => {
	const location = useLocation();
	const navigate = useNavigate();
	const dispatch = useAppDispatch();
	const [addNewPlayer] = useAddNewPlayerMutation();

	function startGame() {

		const addNewPlayerRequest: AddNewPlayerRequest = {
			playerName: location.state.playerName,
			level: location.state.level
		};

		addNewPlayer(addNewPlayerRequest)
			.unwrap()
			.then((res) => {
				dispatch(setName(location.state.playerName));
				dispatch(setLevel(location.state.level+1));
				dispatch(setHealth(res.health));
				dispatch(setArmor(res.armor));
				dispatch(setMoney(res.money));
				navigate('/game-arena');
			})
			.catch((error) => {
				console.log(error);
			});
	}

	return (
		<div className='Home'>
			<div className='Home-welcome'>
				<h1 className='Game-end-header'>{ location.state.winnerName + ' won the round!'}</h1>
				<br />
				{  
					location.state.level < 2 &&
                	<button className='Home-start-button' onClick={startGame} >
						Rematch
                	</button>
				}
			</div>
		</div>
	);
};

export default EndGame;
