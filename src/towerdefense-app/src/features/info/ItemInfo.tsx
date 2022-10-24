import React from 'react';
import { useAppSelector } from '../../app/hooks';
import { GridItem } from '../../models/GridItem';
import './ItemInfo.css';

const ItemInfo: React.FC = () => {

	const playerGrid = useAppSelector((state) => state.grid);

	function getGridItem(id: number): GridItem | undefined{
		return playerGrid.playerGridItems.find( i => i.id == id);
	}
	return (    
		<div className='info-box'>
			{ playerGrid.selectedGridItemId != -1 &&
				<>
					<div className='properties'>
						<h3>Health: {getGridItem(playerGrid.selectedGridItemId)?.health}</h3>
						<h3>Damage: {getGridItem(playerGrid.selectedGridItemId)?.damage}</h3>
						<h3>Level: {getGridItem(playerGrid.selectedGridItemId)?.level}</h3>
					</div>
					<div className='power-ups'>
						{getGridItem(playerGrid.selectedGridItemId)?.powerUps.map((powerUp, i) => <h4 className='power-up' key={i}>{powerUp}</h4>)}
					</div>
				</>
			}
		</div>
	);
};

export default ItemInfo;
