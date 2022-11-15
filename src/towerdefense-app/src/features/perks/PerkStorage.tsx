import React, { useEffect } from 'react';
import './PerkStorage.css';
import PerkTile from './PerkTile';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { getPerks, useApplyPerkMutation } from './PerkStorageSlice';

const PerkStorage: React.FC = () => {

	const dispatch = useAppDispatch();
	const perks = useAppSelector((state) => state.perkStorage.perks);
	const playerName = useAppSelector((state) => state.player.name);


	const [applyPerk] = useApplyPerkMutation();

	useEffect(() => {
		dispatch(getPerks());
	}, [dispatch]);

	return (    
		<div className='perk-storage-container'>
			{perks.map((item, index) => (
				<PerkTile
					key={index}
					id={item.id}
					name={item.name}
				/>
			))}
		</div>
	);
};

export default PerkStorage;
