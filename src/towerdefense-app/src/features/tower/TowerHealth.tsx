import React from 'react';
import { useAppSelector } from '../../app/hooks';

import './TowerHealth.css';

interface Props{
	isEnemy: boolean;
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
			{hearts}
		</div>
	);
};

export default TowerHealth;
