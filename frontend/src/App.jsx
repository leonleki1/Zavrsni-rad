import React from 'react';
import { Link } from 'react-router-dom';
import './App.css';

function App() {
  return (
    <div className="App">
      <nav className="navbar">
        <div className="navbar-brand">
          <h1>
            <Link to="/" style={{ color: 'white', textDecoration: 'none' }}>Paulovnija</Link>
          </h1>
          <img src="/tree.png" alt="Tree Logo" className="tree-logo" />
        </div>
        <ul className="nav-links">
          <li>
            <Link to="/" className="home-icon">
              <span className="home-icon-symbol">🏠</span>
            </Link>
          </li>
          <li className="dropdown">
            <Link to="#">Menu</Link>
            <div className="dropdown-content">
              <Link to="/radnici">Radnici</Link>
              <Link to="#">Zadaci</Link>
              <Link to="#">Rasadnik</Link>
              <Link to="#">Strojevi</Link>
              <Link to="#">Sadnice</Link>
            </div>
          </li>
        </ul>
      </nav>

      {/* Ovdje će se prikazivati sadržaj stranica */}
    </div>
  );
}

export default App;
