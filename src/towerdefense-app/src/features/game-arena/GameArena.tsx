import React, {useEffect, useState} from "react";
import Money from "../money/Money"
import Level from "../level/Level"
import TowerHealth from "../tower/TowerHealth";
import TowerArmor from "../tower/TowerArmor"
import Tower from "../tower/Tower"
import Shop from "../shop/Shop"
import Inventory from "../inventory/Inventory"
import Grid from "../grid/Grid"
import EndTurnButton from "../end-turn-button/EndTurnButton";
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { setName } from '../player/enemy-slice'
import { setEnemyGridItems } from '../grid/grid-slice'
import { useEndTurnMutation} from '../player/player-slice'
import * as signalR from "@microsoft/signalr";


import './GameArena.css';

const GameArena: React.FC = () => {
    const dispatch = useAppDispatch();

    // useState
    const [ connection, setConnection ] = useState<signalR.HubConnection>();
    const [ endTurnText, setEndTurnText ] = useState<string>("End turn");

    // redux State
    const playerName = useAppSelector((state) => state.player.name);
    const enemyName = useAppSelector((state) => state.enemy.name);

    // redux api
    const [endTurn, response] = useEndTurnMutation()

    // useEffect
    useEffect(() => {
        const hubConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7042/gameHub")
            .withAutomaticReconnect()
            .build();

        setConnection(hubConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(result => {
                    console.log('Connected!');
                    connection.invoke("JoinGame", playerName);
    
                    connection.on("EnemyInfo", message => {
                        dispatch(setName(message.name));
                      });
                    connection.on("EndTurn", res => {
                        //console.log(res);
                        dispatch(setEnemyGridItems(res.gridItems));
                        setEndTurnText("End Turn");
                    });     
                })
                .catch(e => console.log('Connection failed: ', e));
        }
    }, [connection]);
  
    // methods
    function onEndTurnClick()
    {
      const payload = {
        name:playerName
      }
      setEndTurnText("Waiting...");
      endTurn(payload)
      .unwrap()
      .then(()=>{
      })
    }
    
    return (
        <div className="root-container">
            <div className="header">
                <Level/>
                <Money/>
            </div>
            <div className="body">
                <div className="tower-container">
                    <h1 className="name-header">{playerName}</h1>
                    <TowerArmor/>
                    <TowerHealth/>
                    <Tower/>
                </div>
                <Grid isEnemy={false}/>
                <Grid isEnemy={true}/>
                <div className="tower-container">
                    <h1 className="name-header">{enemyName}</h1>
                    <TowerArmor/>
                    <TowerHealth/>
                    <Tower/>
                </div>
            </div>
            <div className="footer">
                <Inventory/>
                <EndTurnButton onClick={onEndTurnClick} text={endTurnText}/>
                <Shop/>
            </div>
        </div>
    );
}

export default GameArena;