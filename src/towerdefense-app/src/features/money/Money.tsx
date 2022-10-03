import React from 'react';
import { useAppSelector } from '../../app/hooks';

import './Money.css';

const Money: React.FC = () => {
	const money = useAppSelector((state) => state.player.money);
	return (
		<div className='money-container'>
			<div className='money-tile' />
			<div className='money-amount-container'>
				<p className='money-amount'>{money}</p>
			</div>
		</div>
	);
};

export default Money;
