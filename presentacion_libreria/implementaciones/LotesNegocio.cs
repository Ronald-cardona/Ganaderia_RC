
using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class LotesNegocio : ILotesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Lotes> Consultar(string correo)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/Lotes/Consultar?correo={correo}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Lotes>();

            return JsonConvert.DeserializeObject<List<Lotes>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Lotes Guardar(Lotes entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/Lotes/Guardar?correo={correo}";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Lotes();

            return JsonConvert.DeserializeObject<Lotes>(
                respuesta["Valor"].ToString()!)!;
        }

        public Lotes Modificar(Lotes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Lotes/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Lotes();

            return JsonConvert.DeserializeObject<Lotes>(
                respuesta["Valor"].ToString()!)!;
        }

        public Lotes Borrar(Lotes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Lotes/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Lotes();

            return JsonConvert.DeserializeObject<Lotes>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
