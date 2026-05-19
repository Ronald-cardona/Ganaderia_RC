
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class PotrerosController : ControllerBase
    {
        private IPotrerosNegocio? IPotrerosNegocio;
        public PotrerosController()
        {
            this.IPotrerosNegocio = new PotrerosNegocio();
        }

        [HttpGet]
        public List<Potreros> Consultar()
        {
            if (this.IPotrerosNegocio == null)
                throw new Exception("No implementado");
            return this.IPotrerosNegocio!.Consultar();
        }

        [HttpPost]
        public Potreros Guardar(Potreros entidad)
        {
            if (this.IPotrerosNegocio == null)
                throw new Exception("No implementado");
            return this.IPotrerosNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Potreros Modificar(Potreros entidad)
        {
            if (this.IPotrerosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IPotrerosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Potreros entidad)
        {
            if (this.IPotrerosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IPotrerosNegocio.Borrar(entidad);
        }
    }
}
