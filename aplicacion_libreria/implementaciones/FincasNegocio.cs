
using aplicacion_libreria.clima;
using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http;

namespace aplicacion_libreria.implementaciones
{
    public class FincasNegocio : IFincasNegocio
    {
        private IConexion? iConexion;

        public List<Fincas> Consultar(string correo)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Fincas";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.Fincas!.Where(x => x._usuario!.Correo == correo).ToList();
        }

        public Fincas Guardar(Fincas entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //calculo para las hectareas 

            entidad.ExtensionHectareas = entidad.ExtensionMetro / 10000;


            //para que pueda guardar por usuario
            var usuario = this.iConexion.Usuarios!.First(x => x.Correo == correo);

            entidad.UsuarioId = usuario.Id;

            //obtener coordenadas para el clima
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "User-Agent",
                "GanaderiaRC");

            var direccion =
                entidad.Direcccion?.Trim();

            if (string.IsNullOrEmpty(direccion))
                throw new Exception(
                    "La dirección está vacía");

            var direccionCodificada =
                Uri.EscapeDataString(direccion);

            var url =
            $"https://nominatim.openstreetmap.org/search?q={direccionCodificada}&format=json&limit=1";
            //
            

            var json = client.GetStringAsync(url).Result;


            var resultado =
                JsonConvert.DeserializeObject<List<GeocodingResult>>(json);

            if (resultado != null &&
                resultado.Any())
            {
                entidad.Latitud =
                decimal.Parse(
                resultado.First().Lat!,
                    CultureInfo.InvariantCulture);

                entidad.Longitud =
                    decimal.Parse(
                     resultado.First().Lon!,
                    CultureInfo.InvariantCulture);
            }

            // PROBAR CLIMA

            // LLAMAR CLIMA NEGOCIO

            //var clima =
            //     new ClimasNegocio()
            //            .ConsultarClima(
            //                 entidad.Latitud!.Value,
            //                         entidad.Longitud!.Value);
            //throw new Exception(
            //    $"Temp: {clima.Temperatura}°C - " +
            //    $"Humedad: {clima.Humedad}%");




            this.iConexion.Fincas!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó una nueva Finca";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Fincas Modificar(Fincas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para saber cual finca modificar respecto al usuario 
            var fincaBd = this.iConexion.Fincas!.First(x => x.Id == entidad.Id);
            entidad.UsuarioId = fincaBd.UsuarioId;

            //calculo para las hectareas 

            entidad.ExtensionHectareas = entidad.ExtensionMetro / 10000;

            var entry = this.iConexion!.Entry<Fincas>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó una  Finca";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Fincas entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var finca = this.iConexion.Fincas.FirstOrDefault(e => e.Id == entidad.Id);

            if (finca == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Fincas.Remove(finca);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró una Finca";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
        }
    }
}
