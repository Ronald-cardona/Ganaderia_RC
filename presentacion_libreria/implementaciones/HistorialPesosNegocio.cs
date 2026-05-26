

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class HistorialPesosNegocio : IHistorialPesosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<HistorialPesos> Consultar(string correo)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/HistorialPesos/Consultar?correo={correo}"; // lo ponemos asi para que pueda saber cual es el correo

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<HistorialPesos>();

            return JsonConvert.DeserializeObject<List<HistorialPesos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public HistorialPesos Guardar(HistorialPesos entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/HistorialPesos/Guardar?correo={correo}";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new HistorialPesos();

            return JsonConvert.DeserializeObject<HistorialPesos>(
                respuesta["Valor"].ToString()!)!;
        }

        public HistorialPesos Modificar(HistorialPesos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/HistorialPesos/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new HistorialPesos();

            return JsonConvert.DeserializeObject<HistorialPesos>(
                respuesta["Valor"].ToString()!)!;
        }

        public HistorialPesos Borrar(HistorialPesos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/HistorialPesos/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new HistorialPesos();

            return JsonConvert.DeserializeObject<HistorialPesos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
