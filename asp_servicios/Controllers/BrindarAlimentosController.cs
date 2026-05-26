
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class BrindarAlimentosController : ControllerBase
    {
        private IBrindarAlimentosNegocio? IBrindarAlimentosNegocio;
        public BrindarAlimentosController()
        {
            this.IBrindarAlimentosNegocio = new BrindarAlimentosNegocio();
        }

        [HttpGet]
        public List<BrindarAlimentos> Consultar(string correo)
        {
            if (this.IBrindarAlimentosNegocio == null)
                throw new Exception("No implementado");
            return this.IBrindarAlimentosNegocio!.Consultar(correo);
        }

        [HttpPost]
        public BrindarAlimentos Guardar(BrindarAlimentos entidad, string correo)
        {
            if (this.IBrindarAlimentosNegocio == null)
                throw new Exception("No implementado");
            return this.IBrindarAlimentosNegocio!.Guardar(entidad, correo);
        }

        [HttpPost]
        public BrindarAlimentos Modificar(BrindarAlimentos entidad)
        {
            if (this.IBrindarAlimentosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IBrindarAlimentosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(BrindarAlimentos entidad)
        {
            if (this.IBrindarAlimentosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IBrindarAlimentosNegocio.Borrar(entidad);
        }
    }
}
