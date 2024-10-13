using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPaulovnija.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiPaulovnija.Services
{
    public class StrojService : IStrojService
    {
        private readonly PaulovnijaContext _context; 

        public StrojService(PaulovnijaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stroj>> GetAllAsync()
        {
            return await _context.Strojevi.ToListAsync();
        }

        public async Task<Stroj> GetByIdAsync(int id)
        {
            return await _context.Strojevi.FindAsync(id);
        }

        public async Task AddAsync(Stroj stroj)
        {
            await _context.Strojevi.AddAsync(stroj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stroj stroj)
        {
            _context.Strojevi.Update(stroj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)  // Implementirano
        {
            var stroj = await _context.Strojevi.FindAsync(id);
            if (stroj != null)
            {
                _context.Strojevi.Remove(stroj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
