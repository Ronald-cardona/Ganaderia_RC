
using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IEstadosNegocio
    {
        List<Estados> Consultar();
        Estados Guardar(Estados entidad);
        Estados Modificar(Estados entidad);
        Estados Borrar(Estados entidad);
    }
}
