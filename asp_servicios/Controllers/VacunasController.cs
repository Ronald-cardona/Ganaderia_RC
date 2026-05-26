
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class VacunasController : ControllerBase
    {
        private IVacunasNegocio? IVacunasNegocio;
        public VacunasController()
        {
            this.IVacunasNegocio = new VacunasNegocio();
        }

        [HttpGet]
        public List<Vacunas> Consultar(string correo)
        {
            if (this.IVacunasNegocio == null)
                throw new Exception("No implementado");
            return this.IVacunasNegocio!.Consultar(correo);
        }

        [HttpPost]
        public Vacunas Guardar(Vacunas entidad, string correo)
        {
            if (this.IVacunasNegocio == null)
                throw new Exception("No implementado");
            return this.IVacunasNegocio!.Guardar(entidad, correo);
        }

        [HttpPost]
        public Vacunas Modificar(Vacunas entidad)
        {
            if (this.IVacunasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IVacunasNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Vacunas entidad)
        {
            if (this.IVacunasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IVacunasNegocio.Borrar(entidad);
        }
    }
}
