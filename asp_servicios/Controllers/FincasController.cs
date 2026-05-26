
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class FincasController : ControllerBase
    {
        private IFincasNegocio? IFincasNegocio;
        public FincasController()
        {
            this.IFincasNegocio = new FincasNegocio();
        }

        [HttpGet]
        public List<Fincas> Consultar(string correo)
        {
            if (this.IFincasNegocio == null)
                throw new Exception("No implementado");
            return this.IFincasNegocio!.Consultar(correo);
        }

        [HttpPost]
        public Fincas Guardar([FromBody] Fincas entidad, [FromQuery] string correo)
        {
            if (this.IFincasNegocio == null)
                throw new Exception("No implementado");
            return this.IFincasNegocio!.Guardar(entidad, correo);
        }

        [HttpPost]
        public Fincas Modificar(Fincas entidad)
        {
            if (this.IFincasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IFincasNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Fincas entidad)
        {
            if (this.IFincasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IFincasNegocio.Borrar(entidad);
        }
    }
}
