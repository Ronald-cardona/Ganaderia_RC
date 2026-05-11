
using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface ISubastasPNegocio
    {
        List<SubastasP> Consultar();
        SubastasP Guardar(SubastasP entidad);

        SubastasP Modificar(SubastasP entidad);
        void Borrar(SubastasP entidad);
    }
}
