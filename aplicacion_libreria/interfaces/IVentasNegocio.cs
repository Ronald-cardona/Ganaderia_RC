

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IVentasNegocio
    {
        List<Ventas> Consultar(string correo);
        Ventas Guardar(Ventas entidad, string correo);

        Ventas Modificar(Ventas entidad);
        void Borrar(Ventas entidad);
    }
}
