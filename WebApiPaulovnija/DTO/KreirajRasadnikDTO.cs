using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiPaulovnija.DTO
{
    public class KreirajRasadnikDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "Naziv ne može biti duži od 100 znakova.")]
        [JsonPropertyName("naziv")]
        public string Naziv { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lokacija ne može biti duža od 100 znakova.")]
        [JsonPropertyName("lokacija")]
        public string Lokacija { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Površina mora biti pozitivna.")]
        [JsonPropertyName("povrsina")]
        public decimal Povrsina { get; set; }

        [Required]
        [JsonPropertyName("datum_otvaranja")]
        public DateTime Datum_otvaranja { get; set; }
    }
}
