

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IProveedoresNegocio
    {
        List<Proveedores> Consultar();
        Proveedores Guardar(Proveedores entidad);

        Proveedores Modificar(Proveedores entidad);
        void Borrar(Proveedores entidad);
    }
}
