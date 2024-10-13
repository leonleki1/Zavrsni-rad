using System.Text.Json.Serialization;

namespace WebApiPaulovnija.Models
{
    public class Rasadnik
    {
        [JsonPropertyName("id_rasadnika")]
        public int ID_Rasadnika { get; set; }

        [JsonPropertyName("naziv")]
        public string Naziv { get; set; }

        [JsonPropertyName("lokacija")]
        public string Lokacija { get; set; }

        [JsonPropertyName("povrsina")]
        public decimal Povrsina { get; set; }

        [JsonPropertyName("datum_otvaranja")]
        public DateTime Datum_otvaranja { get; set; }

        public ICollection<Sadnica> Sadnice { get; set; }
    }
}
