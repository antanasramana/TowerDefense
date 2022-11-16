import React, { useEffect } from 'react';
import './PerkStorage.css';
import PerkTile from './PerkTile';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { getPerks, useApplyPerkMutation } from './PerkStorageSlice';
import { ApplyPerkRequest } from '../../contracts/ApplyPerkRequest';

const PerkStorage: React.FC = () => {

	const dispatch = useAppDispatch();
	const perks = useAppSelector((state) => state.perkStorage.perks);
	const callingPlayerName = useAppSelector((state) => state.player.name);

	const [applyPerk] = useApplyPerkMutation();  

	function onPerkItemClick(id: number) {
		
		const applyPerkRequest : ApplyPerkRequest = {
			perkId: id,
			playerName: callingPlayerName
		};
		console.log(applyPerkRequest);
		applyPerk(applyPerkRequest)
			.unwrap()
			.then(() => {
				dispatch(getPerks());
			});

	}

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
					onPerkTileClick={onPerkItemClick}
				/>
			))}
		</div>
	);
};

export default PerkStorage;
