

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface ILotesNegocio
    {
        List<Lotes> Consultar();
        Lotes Guardar(Lotes entidad);

        Lotes Modificar(Lotes entidad);
        void Borrar(Lotes entidad);
    }
}
