

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IComprasNegocio
    {
        List<Compras> Consultar();
        Compras Guardar(Compras entidad);
        Compras Modificar(Compras entidad);
        Compras Borrar(Compras entidad);
    }
}
