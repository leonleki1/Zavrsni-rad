namespace WebApiPaulovnija.DTO
{
    public class KreirajSadnicuDTO

    {
       
        public string Vrsta { get; set; } 
        public decimal Visina { get; set; } 
        public int Starost { get; set; } 
        public DateTime Datum_sadnje { get; set; } 
        public int ID_Rasadnika { get; set; }
    }
}
