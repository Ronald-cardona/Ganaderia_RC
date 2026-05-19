

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface ISubastasCNegocio
    {
        List<SubastasC> Consultar();
        SubastasC Guardar(SubastasC entidad);
        SubastasC Modificar(SubastasC entidad);
        SubastasC Borrar(SubastasC entidad);
    }
}
