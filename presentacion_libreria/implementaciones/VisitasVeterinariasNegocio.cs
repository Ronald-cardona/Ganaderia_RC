

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class VisitasVeterinariasNegocio : IVisitasVeterinariasNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<VisitasVeterinarias> Consultar(string correo)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/VisitasVeterinarias/Consultar?correo={correo}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<VisitasVeterinarias>();

            return JsonConvert.DeserializeObject<List<VisitasVeterinarias>>(
                respuesta["Valor"].ToString()!)!;
        }

        public VisitasVeterinarias Guardar(VisitasVeterinarias entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/VisitasVeterinarias/Guardar?correo={correo}";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new VisitasVeterinarias();

            return JsonConvert.DeserializeObject<VisitasVeterinarias>(
                respuesta["Valor"].ToString()!)!;
        }

        public VisitasVeterinarias Modificar(VisitasVeterinarias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/VisitasVeterinarias/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new VisitasVeterinarias();

            return JsonConvert.DeserializeObject<VisitasVeterinarias>(
                respuesta["Valor"].ToString()!)!;
        }

        public VisitasVeterinarias Borrar(VisitasVeterinarias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/VisitasVeterinarias/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new VisitasVeterinarias();

            return JsonConvert.DeserializeObject<VisitasVeterinarias>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
