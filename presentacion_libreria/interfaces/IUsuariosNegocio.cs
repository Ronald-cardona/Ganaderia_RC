

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IUsuariosNegocio
    {
        List<Usuarios> Consultar();
        Usuarios Guardar(Usuarios entidad);
        Usuarios Modificar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
    }
}
