

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IPersonasNaturalesCNegocio
    {
        List<PersonasNaturalesC> Consultar();
        PersonasNaturalesC Guardar(PersonasNaturalesC entidad);
        PersonasNaturalesC Modificar(PersonasNaturalesC entidad);
        PersonasNaturalesC Borrar(PersonasNaturalesC entidad);
    }
}
