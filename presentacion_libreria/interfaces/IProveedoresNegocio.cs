

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IProveedoresNegocio
    {
        List<Proveedores> Consultar();
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
    }
}
