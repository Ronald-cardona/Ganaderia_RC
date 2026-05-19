using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
   
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubastasPController : ControllerBase
    {
        private ISubastasPNegocio? ISubastasPNegocio;
        public SubastasPController()
        {
            this.ISubastasPNegocio = new SubastasPNegocio();
        }

        [HttpGet]
        public List<SubastasP> Consultar()
        {
            if (this.ISubastasPNegocio == null)
                throw new Exception("No implementado");
            return this.ISubastasPNegocio!.Consultar();
        }

        [HttpPost]
        public SubastasP Guardar(SubastasP entidad)
        {
            if (this.ISubastasPNegocio == null)
                throw new Exception("No implementado");
            return this.ISubastasPNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public SubastasP Modificar(SubastasP entidad)
        {
            if (this.ISubastasPNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.ISubastasPNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(SubastasP entidad)
        {
            if (this.ISubastasPNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.ISubastasPNegocio.Borrar(entidad);
        }
    }
}
