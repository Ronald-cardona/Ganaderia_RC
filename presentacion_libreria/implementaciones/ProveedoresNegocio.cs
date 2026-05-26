

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class ProveedoresNegocio : IProveedoresNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Proveedores> Consultar(string correo)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/Proveedores/Consultar?correo={correo}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Proveedores>();

            return JsonConvert.DeserializeObject<List<Proveedores>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Proveedores Guardar(Proveedores entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/Proveedores/Guardar?correo={correo}";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Proveedores();

            return JsonConvert.DeserializeObject<Proveedores>(
                respuesta["Valor"].ToString()!)!;
        }

        public Proveedores Modificar(Proveedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Proveedores/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Proveedores();

            return JsonConvert.DeserializeObject<Proveedores>(
                respuesta["Valor"].ToString()!)!;
        }

        public Proveedores Borrar(Proveedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Proveedores/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Proveedores();

            return JsonConvert.DeserializeObject<Proveedores>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
