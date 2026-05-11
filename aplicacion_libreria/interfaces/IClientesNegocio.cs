

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IClientesNegocio
    {
        List<Clientes> Consultar();
        Clientes Guardar(Clientes entidad);

        Clientes Modificar(Clientes entidad);
        void Borrar(Clientes entidad);
    }
}
