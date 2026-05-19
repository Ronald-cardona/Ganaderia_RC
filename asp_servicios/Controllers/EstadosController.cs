
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstadosController : ControllerBase
    {
        private IEstadosNegocio? IEstadosNegocio;
        public EstadosController()
        {
            this.IEstadosNegocio = new EstadosNegocio();
        }

        [HttpGet]
        public List<Estados> Consultar()
        {
            if (this.IEstadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosNegocio!.Consultar();
        }

        [HttpPost]
        public Estados Guardar(Estados entidad)
        {
            if (this.IEstadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Estados Modificar(Estados entidad)
        {
            if (this.IEstadosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IEstadosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Estados entidad)
        {
            if (this.IEstadosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IEstadosNegocio.Borrar(entidad);
        }
    }
}
