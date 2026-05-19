

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class BrindarSuplementosNegocio : IBrindarSuplementosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<BrindarSuplementos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/BrindarSuplementos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<BrindarSuplementos>();

            return JsonConvert.DeserializeObject<List<BrindarSuplementos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public BrindarSuplementos Guardar(BrindarSuplementos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/BrindarSuplementos/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new BrindarSuplementos();

            return JsonConvert.DeserializeObject<BrindarSuplementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public BrindarSuplementos Modificar(BrindarSuplementos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/BrindarSuplementos/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new BrindarSuplementos();

            return JsonConvert.DeserializeObject<BrindarSuplementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public BrindarSuplementos Borrar(BrindarSuplementos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/BrindarSuplementos/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new BrindarSuplementos();

            return JsonConvert.DeserializeObject<BrindarSuplementos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
