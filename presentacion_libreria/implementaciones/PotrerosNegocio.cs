

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class PotrerosNegocio : IPotrerosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Potreros> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Potreros/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Potreros>();

            return JsonConvert.DeserializeObject<List<Potreros>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Potreros Guardar(Potreros entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Potreros/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Potreros();

            return JsonConvert.DeserializeObject<Potreros>(
                respuesta["Valor"].ToString()!)!;
        }

        public Potreros Modificar(Potreros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Potreros/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Potreros();

            return JsonConvert.DeserializeObject<Potreros>(
                respuesta["Valor"].ToString()!)!;
        }

        public Potreros Borrar(Potreros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Potreros/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Potreros();

            return JsonConvert.DeserializeObject<Potreros>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
