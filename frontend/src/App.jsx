import './App.css';
import treeLogo from '/tree.png';

function App() {
  return (
    <div>
      <nav className="navbar navbar-expand-lg navbar-light fixed-top">
        <div className="container-fluid">
          <a className="navbar-brand" href="#">
            Paulovnija
          </a>
          <img src={treeLogo} alt="Tree Logo" width="50" height="50" className="tree-logo" />
          <a className="nav-link" href="#">O Paulovniji</a>
          <div className="dropdown ms-auto">
            <a className="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
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
      </nav>
    </div>
  );
}

export default App;
