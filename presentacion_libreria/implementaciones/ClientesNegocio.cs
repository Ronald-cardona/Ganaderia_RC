

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class ClientesNegocio : IClientesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Clientes> Consultar(string correo)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/Clientes/Consultar?correo={correo}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Clientes>();

            return JsonConvert.DeserializeObject<List<Clientes>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Clientes Guardar(Clientes entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/Clientes/Guardar?correo={correo}";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Clientes();

            return JsonConvert.DeserializeObject<Clientes>(
                respuesta["Valor"].ToString()!)!;
        }

        public Clientes Modificar(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Clientes/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Clientes();

            return JsonConvert.DeserializeObject<Clientes>(
                respuesta["Valor"].ToString()!)!;
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/Clientes/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Clientes();

            return JsonConvert.DeserializeObject<Clientes>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
