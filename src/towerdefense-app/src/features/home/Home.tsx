import React from 'react';
import './Home.css';

const Home: React.FC = () => {
  return (
    <div className="Home">
      <div className="Home-welcome">
        <h1 className="Home-header">Tower Defense</h1>
        <a href="gamearena" className="Home-start-button">Start game</a>
      </div>
    </div>
  );
}

export default Home;
