using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;

using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
   
    [ApiController]
    [Route("[controller]/[action]")]
    public class IngresosController : ControllerBase
    {
        private IIngresosNegocio? IIngresosNegocio;
        public IngresosController()
        {
            this.IIngresosNegocio = new IngresosNegocio();
        }

        [HttpGet]
        public List<Ingresos> Consultar()
        {
            if (this.IIngresosNegocio == null)
                throw new Exception("No implementado");
            return this.IIngresosNegocio!.Consultar();
        }

        [HttpPost]
        public Ingresos Guardar(Ingresos entidad)
        {
            if (this.IIngresosNegocio == null)
                throw new Exception("No implementado");
            return this.IIngresosNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Ingresos Modificar(Ingresos entidad)
        {
            if (this.IIngresosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IIngresosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Ingresos entidad)
        {
            if (this.IIngresosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IIngresosNegocio.Borrar(entidad);
        }
    }
}
