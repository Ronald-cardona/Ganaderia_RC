
using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IEmpleadosNegocio
    {
        List<Empleados> Consultar();
        Empleados Guardar(Empleados entidad);

        Empleados Modificar(Empleados entidad);
        void Borrar(Empleados entidad);
    }
}
