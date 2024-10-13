import React, { useState, useEffect } from 'react';
import './App.css';

function Radnici() {
  const [radnici, setRadnici] = useState([]);
  const [ime, setIme] = useState('');
  const [prezime, setPrezime] = useState('');
  const [godine, setGodine] = useState('');
  const [pozicija, setPozicija] = useState('');
  const [plata, setPlata] = useState('');
  const [selectedId, setSelectedId] = useState(null);

  useEffect(() => {
    fetchRadnici();
  }, []);

  const fetchRadnici = async () => {
    try {
      const response = await fetch('https://paulovnija.site/api/v1/Radnik');
      if (!response.ok) throw new Error('Network response was not ok');
      const data = await response.json();
      console.log('Data received:', data);
      setRadnici(data);
    } catch (error) {
      console.error('There was a problem with the fetch operation:', error);
    }
  };

  const dodajRadnika = async () => {
    const newRadnik = { ime, prezime, godine: parseInt(godine), pozicija, plata: parseFloat(plata) };
    try {
      const response = await fetch('https://paulovnija.site/api/v1/Radnik', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newRadnik),
      });
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      fetchRadnici();
      resetForm();
    } catch (error) {
      console.error('Failed to add worker:', error);
    }
  };

  const obrisiRadnika = async (id) => {
    if (!id) {
      console.error('Invalid ID:', id);
      return;
    }
    try {
      const response = await fetch(`https://paulovnija.site/api/v1/Radnik/${id}`, {
        method: 'DELETE',
      });
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      fetchRadnici();
    } catch (error) {
      console.error('Failed to delete worker:', error);
    }
  };

  const azurirajRadnika = async () => {
    const updatedRadnik = { ime, prezime, godine: parseInt(godine), pozicija, plata: parseFloat(plata) };
    try {
      const response = await fetch(`https://paulovnija.site/api/v1/Radnik/${selectedId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedRadnik),
      });
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      fetchRadnici(); // Refresh the list after updating
      resetForm();
    } catch (error) {
      console.error('Failed to update worker:', error);
    }
  };

  const resetForm = () => {
    setIme('');
    setPrezime('');
    setGodine('');
    setPozicija('');
    setPlata('');
    setSelectedId(null);
  };

  const odaberiRadnika = (radnik) => {
    setIme(radnik.ime);
    setPrezime(radnik.prezime);
    setGodine(radnik.godine);
    setPozicija(radnik.pozicija);
    setPlata(radnik.plata);
    setSelectedId(radnik.iD_Radnika);
  };

  return (
    <div>
      <h2>Radnici</h2>
      <form onSubmit={(e) => { e.preventDefault(); selectedId ? azurirajRadnika() : dodajRadnika(); }}>
        <input type="text" placeholder="Ime" value={ime} onChange={(e) => setIme(e.target.value)} required />
        <input type="text" placeholder="Prezime" value={prezime} onChange={(e) => setPrezime(e.target.value)} required />
        <input type="number" placeholder="Godine" value={godine} onChange={(e) => setGodine(e.target.value)} required />
        <input type="text" placeholder="Pozicija" value={pozicija} onChange={(e) => setPozicija(e.target.value)} required />
        <input type="number" placeholder="Plata" value={plata} onChange={(e) => setPlata(e.target.value)} required />
        <button type="submit">{selectedId ? 'Ažuriraj Radnika' : 'Dodaj Radnika'}</button>
      </form>

      <table>
        <thead>
          <tr>
            <th>ID Radnika</th>
            <th>Ime</th>
            <th>Prezime</th>
            <th>Godine</th>
            <th>Pozicija</th>
            <th>Plata</th>
            <th>Akcije</th>
          </tr>
        </thead>
        <tbody>
          {radnici.filter(radnik => radnik.iD_Radnika).map((radnik) => (
            <tr key={radnik.iD_Radnika}>
              <td>{radnik.iD_Radnika}</td>
              <td>{radnik.ime}</td>
              <td>{radnik.prezime}</td>
              <td>{radnik.godine}</td>
              <td>{radnik.pozicija}</td>
              <td>{radnik.plata}</td>
              <td>
                <button onClick={() => odaberiRadnika(radnik)}>Ažuriraj</button>
                <button onClick={() => obrisiRadnika(radnik.iD_Radnika)}>Obriši</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Radnici;
