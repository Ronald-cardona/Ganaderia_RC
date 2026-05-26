

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class BrindarAlimentosNegocio : IBrindarAlimentosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<BrindarAlimentos> Consultar(string correo)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/BrindarAlimentos/Consultar?correo={correo}"; // lo ponemos asi para que pueda saber cual es el correo

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<BrindarAlimentos>();

            return JsonConvert.DeserializeObject<List<BrindarAlimentos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public BrindarAlimentos Guardar(BrindarAlimentos entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/BrindarAlimentos/Guardar?correo={correo}";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new BrindarAlimentos();

            return JsonConvert.DeserializeObject<BrindarAlimentos>(
                respuesta["Valor"].ToString()!)!;
        }

        public BrindarAlimentos Modificar(BrindarAlimentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/BrindarAlimentos/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new BrindarAlimentos();

            return JsonConvert.DeserializeObject<BrindarAlimentos>(
                respuesta["Valor"].ToString()!)!;
        }

        public BrindarAlimentos Borrar(BrindarAlimentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/BrindarAlimentos/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new BrindarAlimentos();

            return JsonConvert.DeserializeObject<BrindarAlimentos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
