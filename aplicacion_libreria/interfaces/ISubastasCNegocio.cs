
using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface ISubastasCNegocio
    {
        List<SubastasC> Consultar();
        SubastasC Guardar(SubastasC entidad);

        SubastasC Modificar(SubastasC entidad);
        void Borrar(SubastasC entidad);
    }
}
