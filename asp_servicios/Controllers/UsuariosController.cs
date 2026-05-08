using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosNegocio? IUsuariosNegocio;
        public UsuariosController()
        {
            this.IUsuariosNegocio = new UsuariosNegocio();
        }

        [HttpGet]
        public List<Usuarios> Consultar()
        {
            if (this.IUsuariosNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuariosNegocio!.Consultar();
        }

        [HttpPost]
        public Usuarios Guardar(Usuarios entidad)
        {
            if (this.IUsuariosNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuariosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Usuarios Modificar(Usuarios entidad)
        {
            if (this.IUsuariosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IUsuariosNegocio.Modificar(entidad);
        }

        [HttpDelete]
        public void Borrar(Usuarios entidad)
        {
            if (this.IUsuariosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IUsuariosNegocio.Borrar(entidad);
        }
    }
}
