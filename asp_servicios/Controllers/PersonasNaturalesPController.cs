
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasNaturalesPController : ControllerBase
    {
        private IPersonasNaturalesPNegocio? IPersonasNaturalesPNegocio;
        public PersonasNaturalesPController()
        {
            this.IPersonasNaturalesPNegocio = new PersonasNaturalesPNegocio();
        }

        [HttpGet]
        public List<PersonasNaturalesP> Consultar()
        {
            if (this.IPersonasNaturalesPNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNaturalesPNegocio!.Consultar();
        }

        [HttpPost]
        public PersonasNaturalesP Guardar(PersonasNaturalesP entidad)
        {
            if (this.IPersonasNaturalesPNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNaturalesPNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public PersonasNaturalesP Modificar(PersonasNaturalesP entidad)
        {
            if (this.IPersonasNaturalesPNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IPersonasNaturalesPNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(PersonasNaturalesP entidad)
        {
            if (this.IPersonasNaturalesPNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IPersonasNaturalesPNegocio.Borrar(entidad);
        }
    }
}
