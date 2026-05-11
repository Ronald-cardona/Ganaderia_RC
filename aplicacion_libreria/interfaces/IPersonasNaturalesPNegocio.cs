

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IPersonasNaturalesPNegocio
    {
        List<PersonasNaturalesP> Consultar();
        PersonasNaturalesP Guardar(PersonasNaturalesP entidad);

        PersonasNaturalesP Modificar(PersonasNaturalesP entidad);
        void Borrar(PersonasNaturalesP entidad);
    }
}
