namespace WebApiPaulovnija.DTO
{
    public class AzurirajStrojDTO
    {
        public int ID_Stroja { get; set; }  
        public string Marka { get; set; }   
        public string Model { get; set; }   
        public int Godiste { get; set; }    
        public string Tip { get; set; }     
        public decimal Kapacitet_rezervoara { get; set; }  
        public int ID_Radnika { get; set; }
    }
}
