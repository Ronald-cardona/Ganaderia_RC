

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class ConfiguracionesNegocio  : IConfiguracionesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Configuraciones> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Configuraciones/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Configuraciones>();

            return JsonConvert.DeserializeObject<List<Configuraciones>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Configuraciones Guardar(Configuraciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Configuraciones/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Configuraciones();

            return JsonConvert.DeserializeObject<Configuraciones>(
                respuesta["Valor"].ToString()!)!;
        }

        public Configuraciones Modificar(Configuraciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Configuraciones/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Configuraciones();

            return JsonConvert.DeserializeObject<Configuraciones>(
                respuesta["Valor"].ToString()!)!;
        }

        public Configuraciones Borrar(Configuraciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Configuraciones/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Configuraciones();

            return JsonConvert.DeserializeObject<Configuraciones>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
