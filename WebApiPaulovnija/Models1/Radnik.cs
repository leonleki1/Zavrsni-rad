namespace WebApiPaulovnija.Models
{
    public class Radnik
    {
        public int ID_Radnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Godine { get; set; }
        public string Pozicija { get; set; }
        public decimal Plata { get; set; }

        public ICollection<Zadatak> Zadaci { get; set; }
        public ICollection<Stroj> Strojevi { get; set; }
    }
}
