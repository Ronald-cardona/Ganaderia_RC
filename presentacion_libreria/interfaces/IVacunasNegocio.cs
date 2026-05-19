

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IVacunasNegocio
    {
        List<Vacunas> Consultar();
        Vacunas Guardar(Vacunas entidad);
        Vacunas Modificar(Vacunas entidad);
        Vacunas Borrar(Vacunas entidad);
    }
}
