

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IPersonasNaturalesP
    {
        List<PersonasNaturalesP> Consultar();
        PersonasNaturalesP Guardar(PersonasNaturalesP entidad);
        PersonasNaturalesP Modificar(PersonasNaturalesP entidad);
        PersonasNaturalesP Borrar(PersonasNaturalesP entidad);
    }
}
