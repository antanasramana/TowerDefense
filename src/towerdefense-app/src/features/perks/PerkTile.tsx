import React from 'react';

interface Props {
	id: number,
    name: string
}

const PerkTile: React.FC<Props> = (props) => {
	console.log(props);
	return (    
		<div className='perk-tile'>
			{props.name}
		</div>
	);
};

export default PerkTile;
