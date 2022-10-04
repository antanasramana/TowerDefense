import React from 'react';
import { useAppSelector } from '../../app/hooks';

import './TowerArmor.css';

interface Props{
	isEnemy: boolean;
}

const TowerArmor: React.FC<Props> = (props) => {
	//TODO We have to call enemySlice to get the enemyArmor, but it will be implemented after battle simulation
	const armor = props.isEnemy ? useAppSelector((state) => state.player.armor) : useAppSelector((state) => state.player.armor);
	const armorCount = Math.floor(armor / 20);

	const armorPlates: JSX.Element[] = new Array(armorCount);
	for (let index = 0; index < armorCount; index++) {
		armorPlates.push(<div key={index} className='tower-armor-tile' />);
	}

	return (
		<div className='tower-armor-container'>
			{armorPlates}
		</div>
	);
};

export default TowerArmor;
