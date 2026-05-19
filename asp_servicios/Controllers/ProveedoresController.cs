
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControllerBase
    {
        private IProveedoresNegocio? IProveedoresNegocio;
        public ProveedoresController()
        {
            this.IProveedoresNegocio = new ProveedoresNegocio();
        }

        [HttpGet]
        public List<Proveedores> Consultar()
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Consultar();
        }

        [HttpPost]
        public Proveedores Guardar(Proveedores entidad)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Proveedores Modificar(Proveedores entidad)
        {
            if (this.IProveedoresNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IProveedoresNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Proveedores entidad)
        {
            if (this.IProveedoresNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IProveedoresNegocio.Borrar(entidad);
        }
    }
}
