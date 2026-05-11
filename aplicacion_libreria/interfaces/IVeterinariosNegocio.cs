

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IVeterinariosNegocio
    {
        List<Veterinarios> Consultar();
        Veterinarios Guardar(Veterinarios entidad);

        Veterinarios Modificar(Veterinarios entidad);
        void Borrar(Veterinarios entidad);
    }
}
