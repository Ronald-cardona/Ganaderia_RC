

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IAplicacionVacunasNegocio
    {
        List<AplicacionVacunas> Consultar();
        AplicacionVacunas Guardar(AplicacionVacunas entidad);

        AplicacionVacunas Modificar(AplicacionVacunas entidad);
        void Borrar(AplicacionVacunas entidad);
    }
}
