
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
   
    [ApiController]
    [Route("[controller]/[action]")]
    public class VeterinariosController : ControllerBase
    {
        private IVeterinariosNegocio? IVeterinariosNegocio;
        public VeterinariosController()
        {
            this.IVeterinariosNegocio = new VeterinariosNegocio();
        }

        [HttpGet]
        public List<Veterinarios> Consultar()
        {
            if (this.IVeterinariosNegocio == null)
                throw new Exception("No implementado");
            return this.IVeterinariosNegocio!.Consultar();
        }

        [HttpPost]
        public Veterinarios Guardar(Veterinarios entidad)
        {
            if (this.IVeterinariosNegocio == null)
                throw new Exception("No implementado");
            return this.IVeterinariosNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Veterinarios Modificar(Veterinarios entidad)
        {
            if (this.IVeterinariosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IVeterinariosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Veterinarios entidad)
        {
            if (this.IVeterinariosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IVeterinariosNegocio.Borrar(entidad);
        }
    }
}
