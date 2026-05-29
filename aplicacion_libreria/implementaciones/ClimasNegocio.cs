

using aplicacion_libreria.clima;
using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using System.Globalization;

namespace aplicacion_libreria.implementaciones
{
    public class ClimasNegocio 
    {
        public Climas ConsultarClima(decimal latitud, decimal longitud)
           
        {
            using var client = new HttpClient();
           

            var lat = latitud.ToString(CultureInfo.InvariantCulture);
            

            var lon = longitud.ToString(CultureInfo.InvariantCulture);
            

            var url =
                $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,relative_humidity_2m,wind_speed_10m,precipitation,weather_code";


            var json = client.GetStringAsync(url).Result;
           

            var respuesta = JsonConvert.DeserializeObject<ClimaRespuesta>(json);
           

            if (respuesta?.Current == null)
                throw new Exception("No fue posible consultar el clima");
           

            return new Climas
            {
                Temperatura = respuesta.Current.Temperatura,
               

                Humedad = respuesta.Current.Humedad,
               

                VelocidadViento = respuesta.Current.VelocidadViento,
                

                Lluvia = respuesta.Current.Lluvia,
               

                CodigoClima = respuesta.Current.CodigoClima
                   
            };
        }
    }
}
