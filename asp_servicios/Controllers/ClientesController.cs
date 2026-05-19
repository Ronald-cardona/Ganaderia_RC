using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;

using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private IClientesNegocio? IClientesNegocio;
        public ClientesController()
        {
            this.IClientesNegocio = new ClientesNegocio();
        }

        [HttpGet]
        public List<Clientes> Consultar()
        {
            if (this.IClientesNegocio == null)
                throw new Exception("No implementado");
            return this.IClientesNegocio!.Consultar();
        }

        [HttpPost]
        public Clientes Guardar(Clientes entidad)
        {
            if (this.IClientesNegocio == null)
                throw new Exception("No implementado");
            return this.IClientesNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Clientes Modificar(Clientes entidad)
        {
            if (this.IClientesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IClientesNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Clientes entidad)
        {
            if (this.IClientesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IClientesNegocio.Borrar(entidad);
        }
    }
}
