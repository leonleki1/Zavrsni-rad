namespace WebApiPaulovnija.DTO
{
    public class AzurirajSadnicuDTO
    {
        public int ID_Sadnice { get; set; }  
        public string Vrsta { get; set; }  
        public decimal Visina { get; set; } 
        public int Starost { get; set; } 
        public DateTime DatumSadnje { get; set; }  
        public int ID_Rasadnika { get; set; }  
    }
}
