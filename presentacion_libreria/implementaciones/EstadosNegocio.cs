
using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class EstadosNegocio : IEstadosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Estados> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Estados/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Estados>();

            return JsonConvert.DeserializeObject<List<Estados>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Estados Guardar(Estados entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Estados/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Estados();

            return JsonConvert.DeserializeObject<Estados>(
                respuesta["Valor"].ToString()!)!;
        }

        public Estados Modificar(Estados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Estados/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Estados();

            return JsonConvert.DeserializeObject<Estados>(
                respuesta["Valor"].ToString()!)!;
        }

        public Estados Borrar(Estados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Estados/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Estados();

            return JsonConvert.DeserializeObject<Estados>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
