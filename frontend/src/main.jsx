// Main.jsx
import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import App from './App';
import Home from './Home';
import Radnici from './Radnici';
import Zadaci from './Zadaci';
import Rasadnici from './Rasadnik';  
import Sadnice from './Sadnice';      
import Strojevi from './Strojevi';
import Kreator from './Kreator'; // Dodaj import za Kreator

const Main = () => {
  return (
    <Router>
      <App />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/radnici" element={<Radnici />} />
        <Route path="/zadaci" element={<Zadaci />} />
        <Route path="/Rasadnik" element={<Rasadnici />} />
        <Route path="/sadnice" element={<Sadnice />} />
        <Route path="/strojevi" element={<Strojevi />} />
        <Route path="/kreator" element={<Kreator />} /> {/* Dodana ruta za Kreatora */}
      </Routes>
    </Router>
  );
};

ReactDOM.createRoot(document.getElementById('root')).render(<Main />);
