
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasController : ControllerBase
    {
        private IPersonasNegocio? IPersonasNegocio;
        public PersonasController()
        {
            this.IPersonasNegocio = new PersonasNegocio();
        }

        [HttpGet]
        public List<Personas> Consultar()
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Consultar();
        }

        [HttpPost]
        public Personas Guardar(Personas entidad)
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Personas Modificar(Personas entidad)
        {
            if (this.IPersonasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IPersonasNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Personas entidad)
        {
            if (this.IPersonasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IPersonasNegocio.Borrar(entidad);
        }
    }
}
