
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class ConfiguracionesController : ControllerBase
    {
        private IConfiguracionesNegocio? IConfiguracionesNegocio;
        public ConfiguracionesController()
        {
            this.IConfiguracionesNegocio = new ConfiguracionesNegocio();
        }

        [HttpGet]
        public List<Configuraciones> Consultar()
        {
            if (this.IConfiguracionesNegocio == null)
                throw new Exception("No implementado");
            return this.IConfiguracionesNegocio!.Consultar();
        }

        [HttpPost]
        public Configuraciones Guardar(Configuraciones entidad)
        {
            if (this.IConfiguracionesNegocio == null)
                throw new Exception("No implementado");
            return this.IConfiguracionesNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Configuraciones Modificar(Configuraciones entidad)
        {
            if (this.IConfiguracionesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IConfiguracionesNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Configuraciones entidad)
        {
            if (this.IConfiguracionesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IConfiguracionesNegocio.Borrar(entidad);
        }
    }
}
