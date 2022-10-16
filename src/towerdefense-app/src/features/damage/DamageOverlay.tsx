import React from 'react';
import './Damage.css';
import { Damage } from '../../models/Damage';
import DamageType from '../../models/DamageType';
import DamageImage from './mappings/DamageImage';

interface Props {
	damage: Damage;
}

const DamageOverlay: React.FC<Props> = (props) => {
	const size = props.damage.size == 1 ? 'Small' : 'Big';
	const imageName = `${DamageType[props.damage.damageType]}_${size}`;
	const imageSource = DamageImage.sourceMap.get(imageName);

	return (
		<div className='damage'
			style={{
				backgroundImage: `url(${imageSource})`
			}}
		/>
	);
};

export default DamageOverlay;
