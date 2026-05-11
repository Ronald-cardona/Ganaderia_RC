

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IComprasNegocio
    {
        List<Compras> Consultar();
        Compras Guardar(Compras entidad);

        Compras Modificar(Compras entidad);
        void Borrar(Compras entidad);
    }
}
