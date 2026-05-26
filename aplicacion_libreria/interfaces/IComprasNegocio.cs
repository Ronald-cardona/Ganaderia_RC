

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IComprasNegocio
    {
        List<Compras> Consultar(string correo);
        Compras Guardar(Compras entidad, string correo);

        Compras Modificar(Compras entidad);
        void Borrar(Compras entidad);
    }
}
