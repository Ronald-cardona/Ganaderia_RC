

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface ISuplementosNegocio
    {
        List<Suplementos> Consultar();
        Suplementos Guardar(Suplementos entidad);
        Suplementos Modificar(Suplementos entidad);
        Suplementos Borrar(Suplementos entidad);
    }
}
