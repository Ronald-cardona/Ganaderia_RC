

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IVacunasNegocio
    {
        List<Vacunas> Consultar(string correo);
        Vacunas Guardar(Vacunas entidad, string correo);

        Vacunas Modificar(Vacunas entidad);
        void Borrar(Vacunas entidad);
    }
}
