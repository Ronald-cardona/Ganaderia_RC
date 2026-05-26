
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class BrindarSuplementosController : ControllerBase
    {
        private IBrindarSuplementosNegocio? IBrindarSuplementosNegocio;
        public BrindarSuplementosController()
        {
            this.IBrindarSuplementosNegocio = new BrindarSuplementosNegocio();
        }

        [HttpGet]
        public List<BrindarSuplementos> Consultar(string correo)
        {
            if (this.IBrindarSuplementosNegocio == null)
                throw new Exception("No implementado");
            return this.IBrindarSuplementosNegocio!.Consultar(correo);
        }

        [HttpPost]
        public BrindarSuplementos Guardar(BrindarSuplementos entidad, string correo)
        {
            if (this.IBrindarSuplementosNegocio == null)
                throw new Exception("No implementado");
            return this.IBrindarSuplementosNegocio!.Guardar(entidad, correo);
        }

        [HttpPost]
        public BrindarSuplementos Modificar(BrindarSuplementos entidad)
        {
            if (this.IBrindarSuplementosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IBrindarSuplementosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(BrindarSuplementos entidad)
        {
            if (this.IBrindarSuplementosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IBrindarSuplementosNegocio.Borrar(entidad);
        }
    }
}
