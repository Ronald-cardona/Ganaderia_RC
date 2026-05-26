
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class SuplementosController : ControllerBase
    {
        private ISuplementosNegocio? ISuplementosNegocio;
        public SuplementosController()
        {
            this.ISuplementosNegocio = new SuplementosNegocio();
        }

        [HttpGet]
        public List<Suplementos> Consultar(string correo)
        {
            if (this.ISuplementosNegocio == null)
                throw new Exception("No implementado");
            return this.ISuplementosNegocio!.Consultar(correo);
        }

        [HttpPost]
        public Suplementos Guardar(Suplementos entidad, string correo)
        {
            if (this.ISuplementosNegocio == null)
                throw new Exception("No implementado");
            return this.ISuplementosNegocio!.Guardar(entidad,correo);
        }

        [HttpPost]
        public Suplementos Modificar(Suplementos entidad)
        {
            if (this.ISuplementosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.ISuplementosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Suplementos entidad)
        {
            if (this.ISuplementosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.ISuplementosNegocio.Borrar(entidad);
        }
    }
}
