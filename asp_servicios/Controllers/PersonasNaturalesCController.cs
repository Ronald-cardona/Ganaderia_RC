
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasNaturalesCController : ControllerBase
    {
        private IPersonasNaturalesCNegocio? IPersonasNaturalesCNegocio;
        public PersonasNaturalesCController()
        {
            this.IPersonasNaturalesCNegocio = new PersonasNaturalesCNegocio();
        }

        [HttpGet]
        public List<PersonasNaturalesC> Consultar()
        {
            if (this.IPersonasNaturalesCNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNaturalesCNegocio!.Consultar();
        }

        [HttpPost]
        public PersonasNaturalesC Guardar(PersonasNaturalesC entidad)
        {
            if (this.IPersonasNaturalesCNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNaturalesCNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public PersonasNaturalesC Modificar(PersonasNaturalesC entidad)
        {
            if (this.IPersonasNaturalesCNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IPersonasNaturalesCNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(PersonasNaturalesC entidad)
        {
            if (this.IPersonasNaturalesCNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IPersonasNaturalesCNegocio.Borrar(entidad);
        }
    }
}
