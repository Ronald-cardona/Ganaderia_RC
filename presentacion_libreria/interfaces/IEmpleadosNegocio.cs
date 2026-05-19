

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IEmpleadosNegocio
    {
        List<Empleados> Consultar();
        Empleados Guardar(Empleados entidad);
        Empleados Modificar(Empleados entidad);
        Empleados Borrar(Empleados entidad);
    }
}
