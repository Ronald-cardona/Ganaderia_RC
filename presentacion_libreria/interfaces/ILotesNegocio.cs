

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface ILotesNegocio
    {
        List<Lotes> Consultar();
        Lotes Guardar(Lotes entidad);
        Lotes Modificar(Lotes entidad);
        Lotes Borrar(Lotes entidad);
    }
}
