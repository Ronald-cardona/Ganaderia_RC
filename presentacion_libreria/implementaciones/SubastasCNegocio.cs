

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class SubastasCNegocio : ISubastasCNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<SubastasC> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/SubastasC/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<SubastasC>();

            return JsonConvert.DeserializeObject<List<SubastasC>>(
                respuesta["Valor"].ToString()!)!;
        }

        public SubastasC Guardar(SubastasC entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/SubastasC/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new SubastasC();

            return JsonConvert.DeserializeObject<SubastasC>(
                respuesta["Valor"].ToString()!)!;
        }

        public SubastasC Modificar(SubastasC entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/SubastasC/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new SubastasC();

            return JsonConvert.DeserializeObject<SubastasC>(
                respuesta["Valor"].ToString()!)!;
        }

        public SubastasC Borrar(SubastasC entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/SubastasC/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new SubastasC();

            return JsonConvert.DeserializeObject<SubastasC>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
