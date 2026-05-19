
using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class PersonasNaturalesPNegocio : IPersonasNaturalesPNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<PersonasNaturalesP> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/PersonasNaturalesP/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<PersonasNaturalesP>();

            return JsonConvert.DeserializeObject<List<PersonasNaturalesP>>(
                respuesta["Valor"].ToString()!)!;
        }

        public PersonasNaturalesP Guardar(PersonasNaturalesP entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/PersonasNaturalesP/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new PersonasNaturalesP();

            return JsonConvert.DeserializeObject<PersonasNaturalesP>(
                respuesta["Valor"].ToString()!)!;
        }

        public PersonasNaturalesP Modificar(PersonasNaturalesP entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/PersonasNaturalesP/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new PersonasNaturalesP();

            return JsonConvert.DeserializeObject<PersonasNaturalesP>(
                respuesta["Valor"].ToString()!)!;
        }

        public PersonasNaturalesP Borrar(PersonasNaturalesP entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/PersonasNaturalesP/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new PersonasNaturalesP();

            return JsonConvert.DeserializeObject<PersonasNaturalesP>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
