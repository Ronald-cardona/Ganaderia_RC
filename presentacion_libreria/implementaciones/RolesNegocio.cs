

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class RolesNegocio : IRolesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Roles> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Roles/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Roles>();

            return JsonConvert.DeserializeObject<List<Roles>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles Guardar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Roles/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles();

            return JsonConvert.DeserializeObject<Roles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles Modificar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Roles/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles();

            return JsonConvert.DeserializeObject<Roles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Roles/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles();

            return JsonConvert.DeserializeObject<Roles>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
