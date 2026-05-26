

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IAplicacionVacunasNegocio
    {
        List<AplicacionVacunas> Consultar(string correo);
        AplicacionVacunas Guardar(AplicacionVacunas entidad, string correo);

        AplicacionVacunas Modificar(AplicacionVacunas entidad);
        void Borrar(AplicacionVacunas entidad);
    }
}
