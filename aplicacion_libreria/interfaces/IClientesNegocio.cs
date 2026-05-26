

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IClientesNegocio
    {
        List<Clientes> Consultar(string correo);
        Clientes Guardar(Clientes entidad, string correo);

        Clientes Modificar(Clientes entidad);
        void Borrar(Clientes entidad);
    }
}
