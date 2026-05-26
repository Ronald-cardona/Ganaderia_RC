

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IAplicacionVacunasNegocio
    {
        List<AplicacionVacunas> Consultar(string correo);
        AplicacionVacunas Guardar(AplicacionVacunas entidad, string correo);
        AplicacionVacunas Modificar(AplicacionVacunas entidad);
        AplicacionVacunas Borrar(AplicacionVacunas entidad);
    }
}
