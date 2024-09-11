import React from 'react';
import './App.css'; // Import CSS za animaciju

function App() {
  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-light fixed-top" style={{ backgroundColor: 'green', padding: '10px 20px' }}>
        <div className="container-fluid">
          <div className="d-flex align-items-center w-100">
            <a className="navbar-brand me-3" href="#" style={{ fontSize: '1.5rem', color: 'white' }}>
              Paulovnija
            </a>
            <img src="/tree.png" alt="Tree Logo" width="50" height="50" className="me-3 tree-logo" />
            <a className="nav-link" href="#" style={{ color: 'white', fontSize: '1.25rem' }}>O Paulovniji</a>
            <div className="dropdown ms-auto">
              <a className="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false" style={{ color: 'white', fontSize: '1.25rem' }}>
                Meni
              </a>
              <ul className="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                <li><a className="dropdown-item" href="#">Radnici</a></li>
                <li><a className="dropdown-item" href="#">Strojevi</a></li>
                <li><a className="dropdown-item" href="#">Rasadnik</a></li>
                <li><a className="dropdown-item" href="#">Zadaci</a></li>
              </ul>
            </div>
          </div>
        </div>
      </nav>
    </>
  );
}

export default App;
