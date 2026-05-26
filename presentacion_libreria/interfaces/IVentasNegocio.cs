

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IVentasNegocio
    {
        List<Ventas> Consultar(string correo);
        Ventas Guardar(Ventas entidad, string correo);
        Ventas Modificar(Ventas entidad);
        Ventas Borrar(Ventas entidad);
    }
}
