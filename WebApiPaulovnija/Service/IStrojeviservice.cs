using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPaulovnija.Models;

namespace WebApiPaulovnija.Services
{
    public interface IStrojService
    {
        Task<IEnumerable<Stroj>> GetAllAsync();
        Task<Stroj> GetByIdAsync(int id);
        Task AddAsync(Stroj stroj);
        Task UpdateAsync(Stroj stroj);
        Task DeleteAsync(int id);  
    }
}
