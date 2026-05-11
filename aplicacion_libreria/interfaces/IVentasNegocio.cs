

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IVentasNegocio
    {
        List<Ventas> Consultar();
        Ventas Guardar(Ventas entidad);

        Ventas Modificar(Ventas entidad);
        void Borrar(Ventas entidad);
    }
}
