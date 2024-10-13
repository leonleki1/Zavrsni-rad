using System.ComponentModel.DataAnnotations;

namespace WebApiPaulovnija.DTO
{
    public class KreirajRadnikaDTO
    {
        [Required(ErrorMessage = "Ime je obavezno.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Godine su obavezne.")]
        public int Godine { get; set; }

        [Required(ErrorMessage = "Pozicija je obavezna.")]
        public string Pozicija { get; set; }

        [Required(ErrorMessage = "Plata je obavezna.")]
        public decimal Plata { get; set; }
    }
}
