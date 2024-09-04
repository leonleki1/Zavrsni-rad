namespace WebApiPaulovnija.Controllers.Models
{
    public class Radnici : Radnik
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public int Godine { get; set; }
        public string? Pozicija { get; set; }
        public decimal Plata { get; set; }
    }
}