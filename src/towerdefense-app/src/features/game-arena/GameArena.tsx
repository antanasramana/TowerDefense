import React from "react";
import Money from "../money/Money"
import Level from "../level/Level"
import TowerHealth from "../tower/TowerHealth";
import TowerArmor from "../tower/TowerArmor"
import Tower from "../tower/Tower"
import Shop from "../shop/Shop"
import Inventory from "../inventory/Inventory"
import Grid from "../grid/Grid"
import EndTurnButton from "../end-turn-button/EndTurnButton";

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
                <Grid/>
                <div className="tower-container">
                    <TowerArmor/>
                    <TowerHealth/>
                    <Tower/>
                </div>
            </div>
            <div className="footer">
                <Inventory/>
                <EndTurnButton/>
                <Shop/>
            </div>
        </div>
    );
}

export default GameArena;