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
        const response = await fetch('https://leki23-001-site1.atempurl.com/api/Radnik'); // ili vaš produkcijski URL
        console.log('Response status:', response.status); // Status kod
        console.log('Response headers:', response.headers.get('content-type')); // Tip sadržaja

        // Ako nije JSON, obavestite korisnika
        if (!response.ok) {
            throw new Error('Network response was not ok, status: ' + response.status);
        }
        
        const contentType = response.headers.get('content-type');
        if (contentType && contentType.includes('application/json')) {
            const data = await response.json();
            console.log('Data received:', data); // Prikaz podataka
            setRadnici(data);
        } else {
            throw new Error('Received content type is not JSON: ' + contentType);
        }
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
};

  const dodajRadnika = async () => {
    const newRadnik = { ime, prezime, godine: parseInt(godine), pozicija, plata: parseFloat(plata) };
    await fetch('https://leki23-001-site1.atempurl.com/api/Radnik/Post', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(newRadnik),
    });
    fetchRadnici();
    resetForm();
  };

  const obrisiRadnika = async (id) => {
    await fetch(`https://leki23-001-site1.atempurl.com/api/Radnik/Delete/${id}`, {
      method: 'DELETE',
    });
    fetchRadnici();
  };

  const azurirajRadnika = async () => {
    const updatedRadnik = { ime, prezime, godine: parseInt(godine), pozicija, plata: parseFloat(plata) };
    await fetch(`https://leki23-001-site1.atempurl.com/api/Radnik/Put/${selectedId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(updatedRadnik),
    });
    fetchRadnici();
    resetForm();
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
          {radnici.map((radnik) => (
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
