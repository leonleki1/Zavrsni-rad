using WebApiPaulovnija.DTO;

public interface IZadatakService
{
    Task<ZadatakDTO> CreateZadatakAsync(KreirajZadatakDTO dto);
    Task<bool> UpdateZadatakAsync(AzurirajZadatakDTO dto);
    Task<bool> DeleteZadatakAsync(int id);
    Task<List<ZadatakDTO>> GetAllZadaciAsync();
    Task<ZadatakDTO> GetZadatakByIdAsync(int id);
}
