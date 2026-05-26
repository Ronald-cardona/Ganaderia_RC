

using Newtonsoft.Json;

namespace aplicacion_libreria.clima
{
    public class ClimaActual
    {
        [JsonProperty("temperature_2m")]
        public double Temperatura { get; set; }

        [JsonProperty("relative_humidity_2m")]
        public double Humedad { get; set; }

        [JsonProperty("wind_speed_10m")]
        public double VelocidadViento { get; set; }

        [JsonProperty("precipitation")]
        public double Lluvia { get; set; }

        [JsonProperty("weather_code")]
        public int CodigoClima { get; set; }
    }
}
