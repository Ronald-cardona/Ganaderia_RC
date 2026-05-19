
using Newtonsoft.Json;
using presentacion_libreria.interfaces;
using System.Text;

namespace presentacion_libreria.implementaciones
{
    public class Comunicaciones : IComunicaciones
    {
        public async Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos)
        {
            var url = datos["Url"].ToString();
            datos.Remove("Url");
            var stringData = datos.ContainsKey("Entidad") ?
                JsonConvert.SerializeObject(datos["Entidad"]) : "{}";
            var body = new StringContent(stringData, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 4, 0);

            HttpResponseMessage message;

            // SI HAY ENTIDAD -> POST
            if (datos.ContainsKey("Entidad"))
                message = await httpClient.PostAsync(url, body);
            else
                message = await httpClient.GetAsync(url);

            if (!message.IsSuccessStatusCode)
                throw new Exception("Error Comunicacion");

            var resp = await message.Content.ReadAsStringAsync();
            httpClient.Dispose(); httpClient = null;

            resp = Replace(resp);
            return new Dictionary<string, object>() {
                { "Valor", resp }
            };
        }

        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
                .Replace("\\r\\n", "")
                .Replace("\\", "")
                .Replace("\\\"", "\"")
                .Replace("\"", "'")
                .Replace("'[", "[")
                .Replace("]'", "]")
                .Replace("'{'", "{'")
                .Replace("\\\\", "\\")
                .Replace("'}'", "'}")
                .Replace("}'", "}")
                .Replace("\\n", "")
                .Replace("\\r", "")
                .Replace("    ", "")
                .Replace("'{", "{")
                .Replace("\"", "")
                .Replace("  ", "")
                .Replace("null", "''");
        }
    }
}
