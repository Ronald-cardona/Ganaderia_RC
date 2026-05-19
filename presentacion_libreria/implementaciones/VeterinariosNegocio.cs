

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class VeterinariosNegocio : IVeterinariosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Veterinarios> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Veterinarios/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Veterinarios>();

            return JsonConvert.DeserializeObject<List<Veterinarios>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Veterinarios Guardar(Veterinarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Veterinarios/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Veterinarios();

            return JsonConvert.DeserializeObject<Veterinarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public Veterinarios Modificar(Veterinarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Veterinarios/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Veterinarios();

            return JsonConvert.DeserializeObject<Veterinarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public Veterinarios Borrar(Veterinarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Veterinarios/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Veterinarios();

            return JsonConvert.DeserializeObject<Veterinarios>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
