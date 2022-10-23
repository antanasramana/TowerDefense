import React from 'react';
import { useAppSelector } from '../../app/hooks';
import './ItemInfo.css';

const ItemInfo: React.FC = () => {

	const playerGrid = useAppSelector((state) => state.grid);
	return (
        
		<div className='info-box'>
			{ playerGrid.selectedGridItemId != -1 &&
                <>
                	<h2>Health: {playerGrid.playerGridItems.find( i => i.id == playerGrid.selectedGridItemId)?.health}</h2>
                	<h2>Damage: {playerGrid.playerGridItems.find( i => i.id == playerGrid.selectedGridItemId)?.damage}</h2>
                	<h2>Level: {playerGrid.playerGridItems.find( i => i.id == playerGrid.selectedGridItemId)?.level}</h2>
                </>
			}
		</div>
	);
};

export default ItemInfo;
