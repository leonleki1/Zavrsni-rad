using System;
using System.ComponentModel.DataAnnotations; 
using WebApiPaulovnija.Models; 

public class Sadnica
{
    [Key] 
    public int ID_Sadnice { get; set; }

    [Required] 
    [StringLength(50)] 
    public string Vrsta { get; set; }

    [Required] 
    [Range(0.01, 999.99)]
    public decimal Visina { get; set; }

    [Required] 
    [Range(0, 100)] 
    public int Starost { get; set; }

    [Required] 
    public DateTime Datum_sadnje { get; set; }

    [Required] 
    public int ID_Rasadnika { get; set; }

    
    public Rasadnik Rasadnik { get; set; }
}
