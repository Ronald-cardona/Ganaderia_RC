

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IVentasNegocio
    {
        List<Ventas> Consultar();
        Ventas Guardar(Ventas entidad);
        Ventas Modificar(Ventas entidad);
        Ventas Borrar(Ventas entidad);
    }
}
