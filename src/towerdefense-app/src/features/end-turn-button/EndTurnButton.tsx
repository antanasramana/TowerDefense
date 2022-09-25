import React from 'react';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { setName, useEndTurnMutation} from '../player/player-slice'
import './EndTurnButton.css';

const EndTurnButton: React.FC = () => {

  const playerName = useAppSelector((state) => state.player.name);
  const [endTurn, response] = useEndTurnMutation()

  function onEndTurnClick()
  {
    const payload = {
      name:playerName
    }
    endTurn(payload)
    .unwrap()
  }

  return (
    <button onClick={onEndTurnClick} className="button-end-turn">End Turn</button>
  );
}

export default EndTurnButton;