
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private IVentasNegocio? IVentasNegocio;
        public VentasController()
        {
            this.IVentasNegocio = new VentasNegocio();
        }

        [HttpGet]
        public List<Ventas> Consultar()
        {
            if (this.IVentasNegocio == null)
                throw new Exception("No implementado");
            return this.IVentasNegocio!.Consultar();
        }

        [HttpPost]
        public Ventas Guardar(Ventas entidad)
        {
            if (this.IVentasNegocio == null)
                throw new Exception("No implementado");
            return this.IVentasNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Ventas Modificar(Ventas entidad)
        {
            if (this.IVentasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IVentasNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Ventas entidad)
        {
            if (this.IVentasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IVentasNegocio.Borrar(entidad);
        }
    }
}
