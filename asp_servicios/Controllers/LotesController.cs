
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
        public List<Lotes> Consultar(string correo)
        {
            if (this.ILotesNegocio == null)
                throw new Exception("No implementado");
            return this.ILotesNegocio!.Consultar(correo);
        }

        [HttpPost]
        public Lotes Guardar([FromBody] Lotes entidad, [FromQuery] string correo)
        {
            if (this.ILotesNegocio == null)
                throw new Exception("No implementado");
            return this.ILotesNegocio!.Guardar( entidad,  correo);
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
