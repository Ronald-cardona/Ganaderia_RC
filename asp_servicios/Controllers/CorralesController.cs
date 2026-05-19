using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;

using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class CorralesController : ControllerBase
    {
        private ICorralesNegocio? ICorralesNegocio;
        public CorralesController()
        {
            this.ICorralesNegocio = new CorralesNegocio();
        }

        [HttpGet]
        public List<Corrales> Consultar()
        {
            if (this.ICorralesNegocio == null)
                throw new Exception("No implementado");
            return this.ICorralesNegocio!.Consultar();
        }

        [HttpPost]
        public Corrales Guardar(Corrales entidad)
        {
            if (this.ICorralesNegocio == null)
                throw new Exception("No implementado");
            return this.ICorralesNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Corrales Modificar(Corrales entidad)
        {
            if (this.ICorralesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.ICorralesNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Corrales entidad)
        {
            if (this.ICorralesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.ICorralesNegocio.Borrar(entidad);
        }
    }
}
