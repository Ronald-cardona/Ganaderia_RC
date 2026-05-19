
using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
   
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpleadosController : ControllerBase
    {
        private IEmpleadosNegocio? IEmpleadosNegocio;
        public EmpleadosController()
        {
            this.IEmpleadosNegocio = new EmpleadosNegocio();
        }

        [HttpGet]
        public List<Empleados> Consultar()
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Consultar();
        }

        [HttpPost]
        public Empleados Guardar(Empleados entidad)
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Guardar(entidad);
        }

        [HttpPost]
        public Empleados Modificar(Empleados entidad)
        {
            if (this.IEmpleadosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            return this.IEmpleadosNegocio.Modificar(entidad);
        }

        [HttpPost]
        public void Borrar(Empleados entidad)
        {
            if (this.IEmpleadosNegocio == null)
            {
                throw new Exception("No implementado");
            }
            this.IEmpleadosNegocio.Borrar(entidad);
        }
    }
}
