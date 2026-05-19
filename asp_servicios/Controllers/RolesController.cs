
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private IRolesNegocio? IRolesNegocio;
        public RolesController()
        {
            this.IRolesNegocio = new RolesNegocio();
        }

        [HttpGet]
        public List<Roles> Consultar()
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.Consultar();
        }

        [HttpPost]
        public Roles Guardar(Roles entidad)
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Roles Modificar(Roles entidad)
        {
            if (this.IRolesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IRolesNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Roles entidad)
        {
            if (this.IRolesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IRolesNegocio.Borrar(entidad);
        }
    }
}
