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
        public List<AplicacionVacunas> Consultar(string correo)
        {
            if (this.IAplicacionVacunasNegocio == null)
                throw new Exception("No implementado");
            return this.IAplicacionVacunasNegocio!.Consultar(correo);
        }

        [HttpPost]
        public AplicacionVacunas Guardar(AplicacionVacunas entidad, string correo)
        {
            if (this.IAplicacionVacunasNegocio == null)
                throw new Exception("No implementado");
            return this.IAplicacionVacunasNegocio!.Guardar(entidad,correo);
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
