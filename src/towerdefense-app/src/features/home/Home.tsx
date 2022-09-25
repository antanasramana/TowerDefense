import React, { useState } from 'react';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { setName, useAddNewPlayerMutation} from '../player/player-slice'
import { useNavigate } from "react-router-dom";
import './Home.css';

const Home: React.FC = () => {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const [addNewPlayer, response] = useAddNewPlayerMutation()

  const [playerName,setPlayerName] = useState("");

  function handleNameChange(name: string) {
    setPlayerName(name);
  }
  function startGame()
  {
    let formData = {
      name: playerName,
    };

    addNewPlayer(formData)
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
        <a className="Home-start-button" onClick={startGame}>Start game</a>
      </div>
    </div>
  );
}

export default Home;
