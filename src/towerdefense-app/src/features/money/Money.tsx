import React from 'react';

import './Money.css';

interface Props {
	value: number;
}

const Money: React.FC<Props> = (props) => {
	return (
		<div className='money-container'>
			<div className='money-tile' />
			<div className='money-amount-container'>
				<p className='money-amount'>{props.value}</p>
			</div>
		</div>
	);
};

export default Money;
