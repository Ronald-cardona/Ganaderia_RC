

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IVacunasNegocio
    {
        List<Vacunas> Consultar();
        Vacunas Guardar(Vacunas entidad);

        Vacunas Modificar(Vacunas entidad);
        void Borrar(Vacunas entidad);
    }
}
