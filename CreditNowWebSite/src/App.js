import React from 'react';
import './styles.css';
import Logo from './components/Images/home.png';
import CustomCard  from './components/CustomCard/index';

const App = () => {
  return (
    <div className="container">
      <div className="left-section">
        <img src={Logo} className="logo" alt="Logo" />
        <CustomCard />
      </div>
      <div className="middle-section"></div>
      <div className="right-section"></div>
    </div>
  );
};

export default App;