using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiPaulovnija.DTO; // Proveri da li je ovo pravi namespace
using WebApiPaulovnija.Models;

namespace WebApiPaulovnija.Services
{
    public class RasadnikService : IRasadnikService
    {
        private readonly PaulovnijaContext _context;

        public RasadnikService(PaulovnijaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RasadnikDTO>> GetAllRasadniciAsync()
        {
            return await _context.Rasadnik
                .Select(r => new RasadnikDTO
                {
                    ID_Rasadnika = r.ID_Rasadnika,
                    Naziv = r.Naziv,
                    Lokacija = r.Lokacija,
                    // Dodaj ostala svojstva prema potrebama
                }).ToListAsync();
        }

        public async Task<RasadnikDTO> GetRasadnikByIdAsync(int id)
        {
            var rasadnik = await _context.Rasadnik.FindAsync(id);
            if (rasadnik == null) return null;

            return new RasadnikDTO
            {
                ID_Rasadnika = rasadnik.ID_Rasadnika,
                Naziv = rasadnik.Naziv,
                Lokacija = rasadnik.Lokacija,
                // Dodaj ostala svojstva prema potrebama
            };
        }

        public async Task<RasadnikDTO> CreateRasadnikAsync(KreirajRasadnikDTO rasadnikDTO)
        {
            var rasadnik = new Rasadnik
            {
                Naziv = rasadnikDTO.Naziv,
                Lokacija = rasadnikDTO.Lokacija,
                // Dodaj ostala svojstva prema potrebama
            };

            await _context.Rasadnik.AddAsync(rasadnik);
            await _context.SaveChangesAsync();

            return new RasadnikDTO
            {
                ID_Rasadnika = rasadnik.ID_Rasadnika,
                Naziv = rasadnik.Naziv,
                Lokacija = rasadnik.Lokacija,
                // Dodaj ostala svojstva prema potrebama
            };
        }

        public async Task<bool> UpdateRasadnikAsync(AzurirajRasadnikDTO rasadnikDTO)
        {
            var rasadnik = await _context.Rasadnik.FindAsync(rasadnikDTO.ID_Rasadnika);
            if (rasadnik == null) return false;

            // Ažuriraj svojstva rasadnika
            rasadnik.Naziv = rasadnikDTO.Naziv;
            rasadnik.Lokacija = rasadnikDTO.Lokacija;
            // Dodaj ostala svojstva prema potrebama

            _context.Rasadnik.Update(rasadnik);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRasadnikAsync(int id)
        {
            var rasadnik = await _context.Rasadnik.FindAsync(id);
            if (rasadnik == null) return false;

            // Ispravka: koristi Remove umesto pokušaja da pozoveš Rasadnik kao metodu
            _context.Rasadnik.Remove(rasadnik); // Ispravka ovde
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
