using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPaulovnija.DTO; // Provjerite naziv prostora imena
using WebApiPaulovnija.Models;

namespace WebApiPaulovnija.Services
{
    public interface IRasadnikService
    {
        Task<IEnumerable<RasadnikDTO>> GetAllRasadniciAsync();
        Task<RasadnikDTO> GetRasadnikByIdAsync(int id);
        Task<RasadnikDTO> CreateRasadnikAsync(KreirajRasadnikDTO rasadnikDTO);
        Task<bool> UpdateRasadnikAsync(AzurirajRasadnikDTO rasadnik);
        Task<bool> DeleteRasadnikAsync(int id);
    }
}
