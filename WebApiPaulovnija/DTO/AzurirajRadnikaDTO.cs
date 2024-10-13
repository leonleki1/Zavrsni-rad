using System.ComponentModel.DataAnnotations;

namespace WebApiPaulovnija.DTO
{
    public class AzurirajRadnikaDTO
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Godine { get; set; }
        public string Pozicija { get; set; }
        public decimal Plata { get; set; }
    }
}
