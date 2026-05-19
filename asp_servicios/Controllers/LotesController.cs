
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class LotesController : ControllerBase
    {
        private ILotesNegocio? ILotesNegocio;
        public LotesController()
        {
            this.ILotesNegocio = new LotesNegocio();
        }

        [HttpGet]
        public List<Lotes> Consultar()
        {
            if (this.ILotesNegocio == null)
                throw new Exception("No implementado");
            return this.ILotesNegocio!.Consultar();
        }

        [HttpPost]
        public Lotes Guardar(Lotes entidad)
        {
            if (this.ILotesNegocio == null)
                throw new Exception("No implementado");
            return this.ILotesNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Lotes Modificar(Lotes entidad)
        {
            if (this.ILotesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.ILotesNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Lotes entidad)
        {
            if (this.ILotesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.ILotesNegocio.Borrar(entidad);
        }
    }
}
