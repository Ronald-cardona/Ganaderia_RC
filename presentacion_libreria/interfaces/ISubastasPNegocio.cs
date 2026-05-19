

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface ISubastasPNegocio
    {
        List<SubastasP> Consultar();
        SubastasP Guardar(SubastasP entidad);
        SubastasP Modificar(SubastasP entidad);
        SubastasP Borrar(SubastasP entidad);
    }
}
