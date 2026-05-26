
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class LugarAnimalesController : ControllerBase
    {
        private ILugarAnimalesNegocio? ILugarAnimalesNegocio;
        public LugarAnimalesController()
        {
            this.ILugarAnimalesNegocio = new LugarAnimalesNegocio();
        }

        [HttpGet]
        public List<LugarAnimales> Consultar(string correo)
        {
            if (this.ILugarAnimalesNegocio == null)
                throw new Exception("No implementado");
            return this.ILugarAnimalesNegocio!.Consultar(correo);
        }

        [HttpPost]
        public LugarAnimales Guardar([FromBody] LugarAnimales entidad, [FromQuery] string correo)
        {
            if (this.ILugarAnimalesNegocio == null)
                throw new Exception("No implementado");
            return this.ILugarAnimalesNegocio!.Guardar(entidad,correo);
        }

        [HttpPost]
        public LugarAnimales Modificar(LugarAnimales entidad)
        {
            if (this.ILugarAnimalesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.ILugarAnimalesNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(LugarAnimales entidad)
        {
            if (this.ILugarAnimalesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.ILugarAnimalesNegocio.Borrar(entidad);
        }
    }
}
