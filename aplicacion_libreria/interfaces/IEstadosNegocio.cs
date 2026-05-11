

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IEstadosNegocio
    {
        List<Estados> Consultar();
        Estados Guardar(Estados entidad);

        Estados Modificar(Estados entidad);
        void Borrar(Estados entidad);
    }
}
