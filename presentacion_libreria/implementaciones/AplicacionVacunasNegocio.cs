
using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class AplicacionVacunasNegocio : IAplicacionVacunasNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<AplicacionVacunas> Consultar(string correo)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/AplicacionVacunas/Consultar?correo={correo}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<AplicacionVacunas>();

            return JsonConvert.DeserializeObject<List<AplicacionVacunas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public AplicacionVacunas Guardar(AplicacionVacunas entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5241/AplicacionVacunas/Guardar?correo={correo}";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new AplicacionVacunas();

            return JsonConvert.DeserializeObject<AplicacionVacunas>(
                respuesta["Valor"].ToString()!)!;
        }

        public AplicacionVacunas Modificar(AplicacionVacunas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/AplicacionVacunas/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new AplicacionVacunas();

            return JsonConvert.DeserializeObject<AplicacionVacunas>(
                respuesta["Valor"].ToString()!)!;
        }

        public AplicacionVacunas Borrar(AplicacionVacunas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/AplicacionVacunas/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new AplicacionVacunas();

            return JsonConvert.DeserializeObject<AplicacionVacunas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
