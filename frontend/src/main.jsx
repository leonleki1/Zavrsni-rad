import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import App from './App';
import Home from './Home';
import Radnici from './Radnici';

const Main = () => {
  return (
    <Router>
      <App />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/radnici" element={<Radnici />} />
        {/* Dodaj ostale rute ovdje */}
      </Routes>
    </Router>
  );
};

ReactDOM.createRoot(document.getElementById('root')).render(<Main />);
