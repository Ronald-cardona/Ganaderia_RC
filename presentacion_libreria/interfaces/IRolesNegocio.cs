

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IRolesNegocio
    {
        List<Roles> Consultar();
        Roles Guardar(Roles entidad);
        Roles Modificar(Roles entidad);
        Roles Borrar(Roles entidad);
    }
}
