

using aplicacion_libreria.entidades;
using Newtonsoft.Json;
using presentacion_libreria.interfaces;

namespace presentacion_libreria.implementaciones
{
    public class LugarAnimalesNegocio : ILugarAnimalesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<LugarAnimales> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/LugarAnimales/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<LugarAnimales>();

            return JsonConvert.DeserializeObject<List<LugarAnimales>>(
                respuesta["Valor"].ToString()!)!;
        }

        public LugarAnimales Guardar(LugarAnimales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5241/LugarAnimales/Guardar";
            datos["Entidad"] = entidad;



            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new LugarAnimales();

            return JsonConvert.DeserializeObject<LugarAnimales>(
                respuesta["Valor"].ToString()!)!;
        }

        public LugarAnimales Modificar(LugarAnimales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/LugarAnimales/Modificar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new LugarAnimales();

            return JsonConvert.DeserializeObject<LugarAnimales>(
                respuesta["Valor"].ToString()!)!;
        }

        public LugarAnimales Borrar(LugarAnimales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El avión no existe");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();

            datos["Url"] = "http://localhost:5241/LugarAnimales/Borrar";
            datos["Entidad"] = entidad;



            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();

            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new LugarAnimales();

            return JsonConvert.DeserializeObject<LugarAnimales>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
