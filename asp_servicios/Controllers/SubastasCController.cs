
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
   
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubastasCController : ControllerBase
    {
        private ISubastasCNegocio? ISubastasCNegocio;
        public SubastasCController()
        {
            this.ISubastasCNegocio = new SubastasCNegocio();
        }

        [HttpGet]
        public List<SubastasC> Consultar()
        {
            if (this.ISubastasCNegocio == null)
                throw new Exception("No implementado");
            return this.ISubastasCNegocio!.Consultar();
        }

        [HttpPost]
        public SubastasC Guardar(SubastasC entidad)
        {
            if (this.ISubastasCNegocio == null)
                throw new Exception("No implementado");
            return this.ISubastasCNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public SubastasC Modificar(SubastasC entidad)
        {
            if (this.ISubastasCNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.ISubastasCNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(SubastasC entidad)
        {
            if (this.ISubastasCNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.ISubastasCNegocio.Borrar(entidad);
        }
    }
}
