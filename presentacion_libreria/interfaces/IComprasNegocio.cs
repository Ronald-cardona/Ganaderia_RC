

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IComprasNegocio
    {
        List<Compras> Consultar(string correo);
        Compras Guardar(Compras entidad, string correo);
        Compras Modificar(Compras entidad);
        Compras Borrar(Compras entidad);
    }
}
