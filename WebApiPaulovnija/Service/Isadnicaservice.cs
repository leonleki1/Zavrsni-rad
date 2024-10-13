using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPaulovnija.DTO; // Provjerite naziv prostora imena
using WebApiPaulovnija.Models;

namespace WebApiPaulovnija.Services
{
    public interface ISadnicaService
    {
        Task<IEnumerable<SadnicaDTO>> GetAllAsync();
        Task<SadnicaDTO> GetByIdAsync(int id);
        Task<SadnicaDTO> AddAsync(KreirajSadnicuDTO sadnicaDTO);
        Task<bool> UpdateAsync(AzurirajSadnicuDTO sadnicaDTO);
        Task<bool> DeleteAsync(int id);
    }
}
