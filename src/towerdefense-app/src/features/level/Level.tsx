import React from 'react';
import { useAppSelector } from '../../app/hooks';

import './Level.css';

const Level: React.FC = () => {
	const level = useAppSelector((state) => state.player.level);
	
	return <div className='level-text'>LEVEL {level + 1}</div>;
};

export default Level;
