

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class PersonasNaturalesCNegocio : IPersonasNaturalesCNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<PersonasNaturalesC> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/PersonasNaturalesC/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<PersonasNaturalesC>();

            return JsonConvert.DeserializeObject<List<PersonasNaturalesC>>(
                respuesta["Valor"].ToString()!)!;
        }

        public PersonasNaturalesC Guardar(PersonasNaturalesC entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/PersonasNaturalesC/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new PersonasNaturalesC();

            return JsonConvert.DeserializeObject<PersonasNaturalesC>(
                respuesta["Valor"].ToString()!)!;
        }

        public PersonasNaturalesC Modificar(PersonasNaturalesC entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/PersonasNaturalesC/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new PersonasNaturalesC();

            return JsonConvert.DeserializeObject<PersonasNaturalesC>(
                respuesta["Valor"].ToString()!)!;
        }

        public PersonasNaturalesC Borrar(PersonasNaturalesC entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/PersonasNaturalesC/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new PersonasNaturalesC();

            return JsonConvert.DeserializeObject<PersonasNaturalesC>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
