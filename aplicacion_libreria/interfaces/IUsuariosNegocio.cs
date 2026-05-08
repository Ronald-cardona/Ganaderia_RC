

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IUsuariosNegocio
    {
        List<Usuarios> Consultar();
        Usuarios Guardar(Usuarios entidad);

        Usuarios Modificar(Usuarios entidad);
        void Borrar(Usuarios entidad);
    }
}
