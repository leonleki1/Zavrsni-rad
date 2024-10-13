using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPaulovnija.Models;

public interface IRadnikService
{
    Task<Radnik> CreateRadnikAsync(Radnik radnik);
    Task<List<Radnik>> GetAllRadniciAsync();
    Task<Radnik> GetRadnikByIdAsync(int id);
    Task<bool> UpdateRadnikAsync(Radnik radnik);
    Task<bool> DeleteRadnikAsync(int id);
}
