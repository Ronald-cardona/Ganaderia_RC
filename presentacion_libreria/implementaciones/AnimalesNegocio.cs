

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class AnimalesNegocio : IAnimalesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Animales> Consultar(string correo)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/Animales/Consultar?correo={correo}"; // lo ponemos asi para que pueda saber cual es el correo

            

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Animales>();

            return JsonConvert.DeserializeObject<List<Animales>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Animales Guardar(Animales entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/Animales/Guardar?correo={correo}";
            datos["Entidad"] = entidad;
           



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Animales();

            return JsonConvert.DeserializeObject<Animales>(
                respuesta["Valor"].ToString()!)!;
        }

        public Animales Modificar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Animales/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Animales();

            return JsonConvert.DeserializeObject<Animales>(
                respuesta["Valor"].ToString()!)!;
        }

        public Animales Borrar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Animales/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Animales();

            return JsonConvert.DeserializeObject<Animales>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
