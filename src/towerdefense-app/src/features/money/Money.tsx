import React from 'react';

import './Money.css';

const Money: React.FC = () => {
  return (
    <div className="money-container">
        <div className="money-tile"/>
        <div className="money-amount-container">
            <p className="money-amount">44137</p>
        </div>
    </div>
  );
}

export default Money;
