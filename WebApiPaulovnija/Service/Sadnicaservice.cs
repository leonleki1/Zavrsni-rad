using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiPaulovnija.Models;
using WebApiPaulovnija.DTO;

namespace WebApiPaulovnija.Services
{
    public class SadnicaService : ISadnicaService
    {
        private readonly PaulovnijaContext _context;

        public SadnicaService(PaulovnijaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SadnicaDTO>> GetAllAsync()
        {
            return await _context.Sadnice
                .Select(s => new SadnicaDTO
                {
                    ID_Sadnice = s.ID_Sadnice,
                    Vrsta = s.Vrsta,
                    Visina = s.Visina,
                    Starost = s.Starost,
                    Datum_sadnje = s.Datum_sadnje,
                    ID_Rasadnika = s.ID_Rasadnika
                }).ToListAsync();
        }

        public async Task<SadnicaDTO> GetByIdAsync(int id)
        {
            var sadnica = await _context.Sadnice.FindAsync(id);
            if (sadnica == null) return null;

            return new SadnicaDTO
            {
                ID_Sadnice = sadnica.ID_Sadnice,
                Vrsta = sadnica.Vrsta,
                Visina = sadnica.Visina,
                Starost = sadnica.Starost,
                Datum_sadnje = sadnica.Datum_sadnje,
                ID_Rasadnika = sadnica.ID_Rasadnika
            };
        }

        public async Task<SadnicaDTO> AddAsync(KreirajSadnicuDTO sadnicaDTO)
        {
            var sadnica = new Sadnica
            {
                Vrsta = sadnicaDTO.Vrsta,
                Visina = sadnicaDTO.Visina,
                Starost = sadnicaDTO.Starost,
                Datum_sadnje = sadnicaDTO.Datum_sadnje,
                ID_Rasadnika = sadnicaDTO.ID_Rasadnika
            };

            await _context.Sadnice.AddAsync(sadnica);
            await _context.SaveChangesAsync();

            // Mapiranje ID_Sadnice iz modela u DTO
            return new SadnicaDTO
            {
                ID_Sadnice = sadnica.ID_Sadnice,
                Vrsta = sadnica.Vrsta,
                Visina = sadnica.Visina,
                Starost = sadnica.Starost,
                Datum_sadnje = sadnica.Datum_sadnje,
                ID_Rasadnika = sadnica.ID_Rasadnika
            };
        }

        public async Task<bool> UpdateAsync(AzurirajSadnicuDTO sadnicaDTO)
        {
            var sadnica = await _context.Sadnice.FindAsync(sadnicaDTO.ID_Sadnice);
            if (sadnica == null) return false;

            sadnica.Vrsta = sadnicaDTO.Vrsta;
            sadnica.Visina = sadnicaDTO.Visina;
            sadnica.Starost = sadnicaDTO.Starost;
            sadnica.Datum_sadnje = sadnicaDTO.DatumSadnje;
            sadnica.ID_Rasadnika = sadnicaDTO.ID_Rasadnika;

            _context.Sadnice.Update(sadnica);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sadnica = await _context.Sadnice.FindAsync(id);
            if (sadnica == null) return false;

            _context.Sadnice.Remove(sadnica);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
