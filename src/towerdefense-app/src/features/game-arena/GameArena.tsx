import React, { useEffect, useState } from 'react';
import Money from '../money/Money';
import Level from '../level/Level';
import TowerHealth from '../tower/TowerHealth';
import TowerArmor from '../tower/TowerArmor';
import Tower from '../tower/Tower';
import Shop from '../shop/Shop';
import Inventory from '../inventory/Inventory';
import Grid from '../grid/Grid';
import EndTurnButton from '../end-turn-button/EndTurnButton';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { setName } from '../player/EnemySlice';
import { setEnemyGridItems } from '../grid/GridSlice';
import { useEndTurnMutation } from '../player/PlayerSlice';
import * as signalR from '@microsoft/signalr';

const SIGNALR_URL = `${process.env.REACT_APP_BACKEND}/gameHub`;

import './GameArena.css';
import { EndTurnRequest } from '../../contracts/EndTurnRequest';

const GameArena: React.FC = () => {
	const dispatch = useAppDispatch();

	// useState
	const [connection, setConnection] = useState<signalR.HubConnection>();
	const [endTurnText, setEndTurnText] = useState<string>('End turn');

	// redux State
	const playerName = useAppSelector((state) => state.player.name);
	const enemyName = useAppSelector((state) => state.enemy.name);

	// redux api
	const [endTurn] = useEndTurnMutation();

	// useEffect
	useEffect(() => {
		const hubConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
			.withUrl(SIGNALR_URL)
			.withAutomaticReconnect()
			.build();

		setConnection(hubConnection);
	}, []);

	useEffect(() => {
		if (connection) {
			connection
				.start()
				.then(() => {
					console.log('Connected!');
					connection.invoke('JoinGame', playerName);

					connection.on('EnemyInfo', (message) => {
						dispatch(setName(message.name));
					});
					connection.on('EndTurn', (res) => {
						dispatch(setEnemyGridItems(res.gridItems));
						setEndTurnText('End Turn');
					});
				})
				.catch((e) => console.log('Connection failed: ', e));
		}
	}, [connection, dispatch, playerName]);

	// methods
	function onEndTurnClick() {
		const endTurnRequest: EndTurnRequest = {
			playerName: playerName,
		};
		setEndTurnText('Waiting...');
		endTurn(endTurnRequest);
	}

	return (
		<div className='root-container'>
			<div className='header'>
				<Level />
				<Money />
			</div>
			<div className='body'>
				<div className='tower-container'>
					<h1 className='name-header'>{playerName}</h1>
					<TowerArmor />
					<TowerHealth />
					<Tower isEnemy={false} />
				</div>
				<Grid isEnemy={false} />
				<Grid isEnemy={true} />
				<div className='tower-container'>
					<h1 className='name-header'>{enemyName}</h1>
					<TowerArmor />
					<TowerHealth />
					<Tower isEnemy={true} />
				</div>
			</div>
			<div className='footer'>
				<Inventory />
				<EndTurnButton onClick={onEndTurnClick} text={endTurnText} />
				<Shop />
			</div>
		</div>
	);
};

export default GameArena;
