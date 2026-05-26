using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class GastosController : ControllerBase
    {
        private IGastosNegocio? IGastosNegocio;
        public GastosController()
        {
            this.IGastosNegocio = new GastosNegocio();
        }

        [HttpGet]
        public List<Gastos> Consultar(string correo)
        {
            if (this.IGastosNegocio == null)
                throw new Exception("No implementado");
            return this.IGastosNegocio!.Consultar(correo);
        }

        [HttpPost]
        public Gastos Guardar(Gastos entidad, string correo)
        {
            if (this.IGastosNegocio == null)
                throw new Exception("No implementado");
            return this.IGastosNegocio!.Guardar(entidad, correo);
        }

        [HttpPost]
        public Gastos Modificar(Gastos entidad)
        {
            if (this.IGastosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IGastosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Gastos entidad)
        {
            if (this.IGastosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IGastosNegocio.Borrar(entidad);
        }
    }
}
