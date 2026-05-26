

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IPersonasNegocio
    {
        List<Personas> Consultar(string correo);
        Personas Guardar(Personas entidad, string correo);

        Personas Modificar(Personas entidad);
        void Borrar(Personas entidad);
    }
}
