

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IProveedoresNegocio
    {
        List<Proveedores> Consultar(string correo);
        Proveedores Guardar(Proveedores entidad, string correo);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
    }
}
