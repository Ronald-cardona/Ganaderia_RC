

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IProveedoresNegocio
    {
        List<Proveedores> Consultar(string correo);
        Proveedores Guardar(Proveedores entidad, string correo);

        Proveedores Modificar(Proveedores entidad);
        void Borrar(Proveedores entidad);
    }
}
