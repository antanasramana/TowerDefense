import React, { useState } from 'react';
import { useAppDispatch } from '../../app/hooks';
import { setName, useAddNewPlayerMutation } from '../player/player-slice'
import { useNavigate } from "react-router-dom";
import './Home.css';
import { AddNewPlayerRequest } from '../../contracts/AddNewPlayerRequest';

const Home: React.FC = () => {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const [addNewPlayer] = useAddNewPlayerMutation()

  const [playerName,setPlayerName] = useState<string>("");

  function handleNameChange(name: string) {
    setPlayerName(name);
  }

  function startGame()
  {
    const addNewPlayerRequest: AddNewPlayerRequest = {
      playerName: playerName,
    };

    addNewPlayer(addNewPlayerRequest)
      .unwrap()
      .then(() => {
        dispatch(setName(playerName));
        navigate("/gamearena");
      }).catch((error) => {
        console.log(error)
      })
  }

  return (
    <div className="Home">
      <div className="Home-welcome">
        <h1 className="Home-header">Tower Defense</h1>
        <input  className="Home-name-input" onChange={(e) => handleNameChange(e.target.value)}></input>
        <br/>
        <button className="Home-start-button" onClick={startGame}>Start game</button>
      </div>
    </div>
  );
}

export default Home;
