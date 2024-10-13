using System.ComponentModel.DataAnnotations;

public class AzurirajZadatakDTO
{
    public int ID_Zadatka { get; set; } // ID zadatka koji se ažurira

    [Required]
    public string Opis { get; set; }

    [Required]
    public DateTime Datum_pocetka { get; set; }

    [Required]
    public DateTime Datum_zavrsetka { get; set; }

    [Required]
    public string Status_Zadatka { get; set; }

    [Required]
    public int ID_Radnika { get; set; } // ID radnika koji je dodeljen zadatku
}
