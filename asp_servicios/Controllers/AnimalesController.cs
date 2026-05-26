using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AnimalesController : ControllerBase
    {

        private IAnimalesNegocio? IAnimalesNegocio;
        public AnimalesController()
        {
            this.IAnimalesNegocio = new AnimalesNegocio();
        }

        [HttpGet]
        public List<Animales> Consultar(string correo)
        {
            if (this.IAnimalesNegocio == null)
                throw new Exception("No implementado");
            return this.IAnimalesNegocio!.Consultar(correo);
        }

        [HttpPost]
        public Animales Guardar([FromBody] Animales entidad, [FromQuery] string correo)
        {
            if (this.IAnimalesNegocio == null)
                throw new Exception("No implementado");
            return this.IAnimalesNegocio!.Guardar(entidad, correo);
        }

        [HttpPost]
        public Animales Modificar(Animales entidad)
        {
            if (this.IAnimalesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IAnimalesNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Animales entidad)
        {
            if (this.IAnimalesNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IAnimalesNegocio.Borrar(entidad);
        }


    }
}
