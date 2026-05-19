using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;

using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
   
    [ApiController]
    [Route("[controller]/[action]")]
    public class AplicacionVacunasController : ControllerBase
    {
        private IAplicacionVacunasNegocio? IAplicacionVacunasNegocio;
        public AplicacionVacunasController()
        {
            this.IAplicacionVacunasNegocio = new AplicacionVacunasNegocio();
        }

        [HttpGet]
        public List<AplicacionVacunas> Consultar()
        {
            if (this.IAplicacionVacunasNegocio == null)
                throw new Exception("No implementado");
            return this.IAplicacionVacunasNegocio!.Consultar();
        }

        [HttpPost]
        public AplicacionVacunas Guardar(AplicacionVacunas entidad)
        {
            if (this.IAplicacionVacunasNegocio == null)
                throw new Exception("No implementado");
            return this.IAplicacionVacunasNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public AplicacionVacunas Modificar(AplicacionVacunas entidad)
        {
            if (this.IAplicacionVacunasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IAplicacionVacunasNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(AplicacionVacunas entidad)
        {
            if (this.IAplicacionVacunasNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IAplicacionVacunasNegocio.Borrar(entidad);
        }
    }
}
