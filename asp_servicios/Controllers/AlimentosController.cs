using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;

using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AlimentosController : ControllerBase
    {
        private IAlimentosNegocio? IAlimentosNegocio;
        public AlimentosController()
        {
            this.IAlimentosNegocio = new AlimentosNegocio();
        }

        [HttpGet]
        public List<Alimentos> Consultar(string correo)
        {
            if (this.IAlimentosNegocio == null)
                throw new Exception("No implementado");
            return this.IAlimentosNegocio!.Consultar(correo);
        }

        [HttpPost]
        public Alimentos Guardar(Alimentos entidad, string correo)
        {
            if (this.IAlimentosNegocio == null)
                throw new Exception("No implementado");
            return this.IAlimentosNegocio!.Guardar(entidad,correo);
        }

        [HttpPost]
        public Alimentos Modificar(Alimentos entidad)
        {
            if (this.IAlimentosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IAlimentosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Alimentos entidad)
        {
            if (this.IAlimentosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IAlimentosNegocio.Borrar(entidad);
        }
    }
}
