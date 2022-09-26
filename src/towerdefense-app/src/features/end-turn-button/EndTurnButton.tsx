import React from 'react';
import './EndTurnButton.css';

interface Props{
  text: string
  onClick: () => void
}

const EndTurnButton: React.FC<Props> = (props) => {
  return (
    <button onClick={props.onClick} className="button-end-turn">{props.text}</button>
  );
}

export default EndTurnButton;