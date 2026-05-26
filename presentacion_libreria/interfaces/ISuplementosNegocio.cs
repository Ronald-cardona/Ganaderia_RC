

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface ISuplementosNegocio
    {
        List<Suplementos> Consultar(string correo);
        Suplementos Guardar(Suplementos entidad, string correo);
        Suplementos Modificar(Suplementos entidad);
        Suplementos Borrar(Suplementos entidad);
    }
}
