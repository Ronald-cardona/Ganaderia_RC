

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IPersonasNegocio
    {
        List<Personas> Consultar(string correo);
        Personas Guardar(Personas entidad, string correo);
        Personas Modificar(Personas entidad);
        Personas Borrar(Personas entidad);
    }
}
