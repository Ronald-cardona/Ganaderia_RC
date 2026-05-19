

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IPersonasNegocio
    {
        List<Personas> Consultar();
        Personas Guardar(Personas entidad);
        Personas Modificar(Personas entidad);
        Personas Borrar(Personas entidad);
    }
}
