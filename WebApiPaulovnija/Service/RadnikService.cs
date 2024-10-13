using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiPaulovnija.Models;

public class RadnikService : IRadnikService
{
    private readonly PaulovnijaContext _context;

    public RadnikService(PaulovnijaContext context)
    {
        _context = context;
    }

    public async Task<Radnik> CreateRadnikAsync(Radnik radnik)
    {
        _context.Radnici.Add(radnik);
        await _context.SaveChangesAsync();
        return radnik;
    }

    public async Task<List<Radnik>> GetAllRadniciAsync()
    {
        return await _context.Radnici.ToListAsync();
    }

    public async Task<Radnik> GetRadnikByIdAsync(int id)
    {
        return await _context.Radnici.FindAsync(id);
    }

    public async Task<bool> UpdateRadnikAsync(Radnik radnik)
    {
        _context.Radnici.Update(radnik);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteRadnikAsync(int id)
    {
        var radnik = await _context.Radnici.FindAsync(id);
        if (radnik == null)
            return false;

        _context.Radnici.Remove(radnik);
        return await _context.SaveChangesAsync() > 0;
    }
}
