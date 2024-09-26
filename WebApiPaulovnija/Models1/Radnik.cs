using System.ComponentModel.DataAnnotations;

namespace WebApiPaulovnija.Controllers.Models
{
    public class Radnik
    {
        [Key]
        public int ID_Radnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Godine { get; set; }
        public string Pozicija { get; set; }
        public decimal Plata { get; set; }
    }
}
