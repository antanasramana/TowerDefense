import React from "react";

import "./Tower.css"

interface Props{
    isEnemy: Boolean
}

const Tower: React.FC<Props> = (props) => {
    return (
        <div className={props.isEnemy ? "tower-tile-enemy" : "tower-tile"}/>
    );
}

export default Tower;

