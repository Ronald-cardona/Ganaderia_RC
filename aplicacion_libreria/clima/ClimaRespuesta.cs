

using Newtonsoft.Json;

namespace aplicacion_libreria.clima
{
    public class ClimaRespuesta
    {
        [JsonProperty("current")]
        public ClimaActual? Current { get; set; }
    }
}
