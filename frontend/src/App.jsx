// App.jsx
import React from 'react';
import { Link, Outlet } from 'react-router-dom';
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
                            <Link to="/zadaci">Zadaci</Link>
                            <Link to="/Rasadnik">Rasadnici</Link> 
                            <Link to="/sadnice">Sadnice</Link>
                            <Link to="/strojevi">Strojevi</Link>
                            
                        </div>
                    </li>
                    {/* Dodaj dugme za Kreatora */}
                    <li>
                        <Link to="/kreator" className="cool-button">Kreator</Link>
                    </li>
                </ul>
            </nav>

            <Outlet /> {/* Ovo omogućava renderovanje odgovarajućih komponenti */}
        </div>
    );
}

export default App;
