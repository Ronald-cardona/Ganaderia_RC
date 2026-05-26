

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface ISuplementosNegocio
    {
        List<Suplementos> Consultar(string correo);
        Suplementos Guardar(Suplementos entidad, string correo);

        Suplementos Modificar(Suplementos entidad);
        void Borrar(Suplementos entidad);
    }
}
