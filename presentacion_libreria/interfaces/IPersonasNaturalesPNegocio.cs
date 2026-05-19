

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IPersonasNaturalesPNegocio
    {
        List<PersonasNaturalesP> Consultar();
        PersonasNaturalesP Guardar(PersonasNaturalesP entidad);
        PersonasNaturalesP Modificar(PersonasNaturalesP entidad);
        PersonasNaturalesP Borrar(PersonasNaturalesP entidad);
    }
}
