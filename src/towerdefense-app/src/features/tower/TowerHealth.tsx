import React from 'react';
import { useAppSelector } from '../../app/hooks';

import './TowerHealth.css';

interface Props{
	isEnemy: boolean;
	value: number;
}

const TowerHealth: React.FC<Props> = (props) => {
	//TODO We have to call enemySlice to get the enemyHp, but it will be implemented after battle simulation
	const health = props.isEnemy ? useAppSelector((state) => state.player.health) : useAppSelector((state) => state.player.health);
	const heartCount = Math.ceil(health / 20);

	const hearts: JSX.Element[] = new Array(heartCount);
	for (let index = 0; index < heartCount; index++) {
		hearts.push(<div key={index} className='tower-health-tile' />);
	}

	return (
		<div className='tower-health-container'>
			<h2 className='health-header' >{props.value}</h2>
		</div>
	);
};

export default TowerHealth;
