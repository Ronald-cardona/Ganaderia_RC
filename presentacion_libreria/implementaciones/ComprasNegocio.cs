
using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class ComprasNegocio : IComprasNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Compras> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Compras/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Compras>();

            return JsonConvert.DeserializeObject<List<Compras>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Compras Guardar(Compras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/Compras/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Compras();

            return JsonConvert.DeserializeObject<Compras>(
                respuesta["Valor"].ToString()!)!;
        }

        public Compras Modificar(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Compras/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Compras();

            return JsonConvert.DeserializeObject<Compras>(
                respuesta["Valor"].ToString()!)!;
        }

        public Compras Borrar(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Compras/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Compras();

            return JsonConvert.DeserializeObject<Compras>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
