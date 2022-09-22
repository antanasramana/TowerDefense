import React from "react";
import Money from "../money/Money"
import Level from "../level/Level"
import TowerHealth from "../tower/TowerHealth";
import TowerArmor from "../tower/TowerArmor"
import Tower from "../tower/Tower"

import './GameArena.css';


const GameArena: React.FC = () => {
    return (
        <div className="root-container">
            <div className="header">
                <Level/>
                <Money/>
            </div>
            <div className="body">
                <div className="tower-container">
                    <TowerArmor/>
                    <TowerHealth/>
                    <Tower/>
                </div>
                <div className="grid"></div>
                <div className="tower-container">
                    <TowerArmor/>
                    <TowerHealth/>
                    <Tower/>
                </div>
            </div>
            <div className="footer"></div>
        </div>
    );
}

export default GameArena;