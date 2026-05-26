using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class ComprasController : ControllerBase
    {
        private IComprasNegocio? IComprasNegocio;
        public ComprasController()
        {
            this.IComprasNegocio = new ComprasNegocio();
        }

        [HttpGet]
        public List<Compras> Consultar(string correo)
        {
            if (this.IComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IComprasNegocio!.Consultar(correo);
        }

        [HttpPost]
        public Compras Guardar(Compras entidad, string correo)
        {
            if (this.IComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IComprasNegocio!.Guardar(entidad, correo);
        }

        [HttpPost]
        public Compras Modificar(Compras entidad)
        {
            if (this.IComprasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IComprasNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Compras entidad)
        {
            if (this.IComprasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IComprasNegocio.Borrar(entidad);
        }
    }
}
