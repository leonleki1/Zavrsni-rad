using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPaulovnija.DTO;
using WebApiPaulovnija.Models;

public class ZadatakService : IZadatakService
{
    private readonly PaulovnijaContext _context;
    private readonly IMapper _mapper;

    public ZadatakService(PaulovnijaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ZadatakDTO> CreateZadatakAsync(KreirajZadatakDTO dto)
    {
        var radnikExists = await _context.Radnici.AnyAsync(r => r.ID_Radnika == dto.ID_Radnika);
        if (!radnikExists)
        {
            throw new Exception("Radnik sa datim ID ne postoji.");
        }

        var zadatak = new Zadatak
        {
            Opis = dto.Opis,
            Datum_pocetka = dto.Datum_pocetka,
            Datum_zavrsetka = dto.Datum_zavrsetka,
            Status_Zadatka = dto.Status_Zadatka,
            ID_Radnika = dto.ID_Radnika
        };

        await _context.Zadaci.AddAsync(zadatak);
        await _context.SaveChangesAsync();

        var zadatakDTO = _mapper.Map<ZadatakDTO>(zadatak);
        return zadatakDTO;
    }


    public async Task<bool> UpdateZadatakAsync(AzurirajZadatakDTO dto)
    {
        var zadatak = await _context.Zadaci.FindAsync(dto.ID_Zadatka);
        if (zadatak == null)
        {
            return false;
        }

        zadatak.Opis = dto.Opis;
        zadatak.Datum_pocetka = dto.Datum_pocetka;
        zadatak.Datum_zavrsetka = dto.Datum_zavrsetka;
        zadatak.Status_Zadatka = dto.Status_Zadatka;
        zadatak.ID_Radnika = dto.ID_Radnika;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteZadatakAsync(int id)
    {
        var zadatak = await _context.Zadaci.FindAsync(id);
        if (zadatak == null)
        {
            return false;
        }

        _context.Zadaci.Remove(zadatak);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ZadatakDTO>> GetAllZadaciAsync()
    {
        var zadaci = await _context.Zadaci.ToListAsync();
        return _mapper.Map<List<ZadatakDTO>>(zadaci);
    }

    public async Task<ZadatakDTO> GetZadatakByIdAsync(int id)
    {
        var zadatak = await _context.Zadaci.FindAsync(id);
        return _mapper.Map<ZadatakDTO>(zadatak);
    }
}
