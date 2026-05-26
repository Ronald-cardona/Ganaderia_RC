

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IClientesNegocio
    {
        List<Clientes> Consultar(string correo);
        Clientes Guardar(Clientes entidad, string correo);
        Clientes Modificar(Clientes entidad);
        Clientes Borrar(Clientes entidad);
    }
}
