

using Newtonsoft.Json;

namespace aplicacion_libreria.clima
{
    public class Resultados
    {
        [JsonProperty("lat")]
        public string? Lat { get; set; }

        [JsonProperty("lon")]
        public string? Lon { get; set; }
    }
}
