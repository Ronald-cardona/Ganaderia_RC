

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class SubastasPNegocio : ISubastasPNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<SubastasP> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/SubastasP/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<SubastasP>();

            return JsonConvert.DeserializeObject<List<SubastasP>>(
                respuesta["Valor"].ToString()!)!;
        }

        public SubastasP Guardar(SubastasP entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/SubastasP/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new SubastasP();

            return JsonConvert.DeserializeObject<SubastasP>(
                respuesta["Valor"].ToString()!)!;
        }

        public SubastasP Modificar(SubastasP entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/SubastasP/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new SubastasP();

            return JsonConvert.DeserializeObject<SubastasP>(
                respuesta["Valor"].ToString()!)!;
        }

        public SubastasP Borrar(SubastasP entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/SubastasP/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new SubastasP();

            return JsonConvert.DeserializeObject<SubastasP>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
