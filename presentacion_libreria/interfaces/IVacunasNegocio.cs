

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IVacunasNegocio
    {
        List<Vacunas> Consultar(string correo);
        Vacunas Guardar(Vacunas entidad, string correo);
        Vacunas Modificar(Vacunas entidad);
        Vacunas Borrar(Vacunas entidad);
    }
}
