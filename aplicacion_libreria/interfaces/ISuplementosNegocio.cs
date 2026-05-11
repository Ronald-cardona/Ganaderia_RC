

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface ISuplementosNegocio
    {
        List<Suplementos> Consultar();
        Suplementos Guardar(Suplementos entidad);

        Suplementos Modificar(Suplementos entidad);
        void Borrar(Suplementos entidad);
    }
}
