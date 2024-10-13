namespace WebApiPaulovnija.DTO
{
    public class ZadatakDTO
    {
        public int ID_Zadatka { get; set; } 
        public string Opis { get; set; }
        public DateTime Datum_pocetka { get; set; }
        public DateTime Datum_zavrsetka { get; set; }
        public string Status_Zadatka { get; set; }
        public int ID_Radnika { get; set; } 
    }
}
