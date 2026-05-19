

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IAplicacionVacunasNegocio
    {
        List<AplicacionVacunas> Consultar();
        AplicacionVacunas Guardar(AplicacionVacunas entidad);
        AplicacionVacunas Modificar(AplicacionVacunas entidad);
        AplicacionVacunas Borrar(AplicacionVacunas entidad);
    }
}
