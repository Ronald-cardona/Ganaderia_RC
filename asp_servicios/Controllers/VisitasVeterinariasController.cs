
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class VisitasVeterinariasController : ControllerBase
    {
        private IVisitasVeterinariasNegocio? IVisitasVeterinariasNegocio;
        public VisitasVeterinariasController()
        {
            this.IVisitasVeterinariasNegocio = new VisitasVeterinariasNegocio();
        }

        [HttpGet]
        public List<VisitasVeterinarias> Consultar(string correo)
        {
            if (this.IVisitasVeterinariasNegocio == null)
                throw new Exception("No implementado");
            return this.IVisitasVeterinariasNegocio!.Consultar(correo);
        }

        [HttpPost]
        public VisitasVeterinarias Guardar(VisitasVeterinarias entidad, string correo)
        {
            if (this.IVisitasVeterinariasNegocio == null)
                throw new Exception("No implementado");
            return this.IVisitasVeterinariasNegocio!.Guardar(entidad,correo);
        }

        [HttpPost]
        public VisitasVeterinarias Modificar(VisitasVeterinarias entidad)
        {
            if (this.IVisitasVeterinariasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IVisitasVeterinariasNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(VisitasVeterinarias entidad)
        {
            if (this.IVisitasVeterinariasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IVisitasVeterinariasNegocio.Borrar(entidad);
        }
    }
}
