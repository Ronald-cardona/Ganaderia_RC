

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface ILotesNegocio
    {
        List<Lotes> Consultar(string correo);
        Lotes Guardar(Lotes entidad, string correo);

        Lotes Modificar(Lotes entidad);
        void Borrar(Lotes entidad);
    }
}
