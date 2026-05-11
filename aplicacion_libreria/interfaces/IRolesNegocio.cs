

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IRolesNegocio
    {
        List<Roles> Consultar();
        Roles Guardar(Roles entidad);

        Roles Modificar(Roles entidad);
        void Borrar(Roles entidad);
    }
}
