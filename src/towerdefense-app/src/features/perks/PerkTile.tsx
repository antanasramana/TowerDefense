import React from 'react';

interface Props {
	id: number,
    name: string,
	onPerkTileClick: (id: number) => void;

}

const PerkTile: React.FC<Props> = (props) => {
	return (    
		<div className='perk-tile' onClick={()=>props.onPerkTileClick(props.id)}>
			{props.name}
		</div>
	);
};

export default PerkTile;
