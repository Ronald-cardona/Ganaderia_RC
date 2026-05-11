

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IPersonasNegocio
    {
        List<Personas> Consultar();
        Personas Guardar(Personas entidad);

        Personas Modificar(Personas entidad);
        void Borrar(Personas entidad);
    }
}
