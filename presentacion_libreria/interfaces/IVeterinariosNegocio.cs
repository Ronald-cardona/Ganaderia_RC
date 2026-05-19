
using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IVeterinariosNegocio
    {
        List<Veterinarios> Consultar();
        Veterinarios Guardar(Veterinarios entidad);
        Veterinarios Modificar(Veterinarios entidad);
        Veterinarios Borrar(Veterinarios entidad);
    }
}
