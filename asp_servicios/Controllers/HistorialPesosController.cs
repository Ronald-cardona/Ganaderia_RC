
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class HistorialPesosController : ControllerBase
    {
        private IHistorialPesosNegocio? IHistorialPesosNegocio;
        public HistorialPesosController()
        {
            this.IHistorialPesosNegocio = new HistorialPesosNegocio();
        }

        [HttpGet]
        public List<HistorialPesos> Consultar(string correo)
        {
            if (this.IHistorialPesosNegocio == null)
                throw new Exception("No implementado");
            return this.IHistorialPesosNegocio!.Consultar(correo);
        }

        [HttpPost]
        public HistorialPesos Guardar(HistorialPesos entidad, string correo)
        {
            if (this.IHistorialPesosNegocio == null)
                throw new Exception("No implementado");
            return this.IHistorialPesosNegocio!.Guardar(entidad,correo);
        }

        [HttpPost]
        public HistorialPesos Modificar(HistorialPesos entidad)
        {
            if (this.IHistorialPesosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IHistorialPesosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(HistorialPesos entidad)
        {
            if (this.IHistorialPesosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IHistorialPesosNegocio.Borrar(entidad);
        }
    }
}
