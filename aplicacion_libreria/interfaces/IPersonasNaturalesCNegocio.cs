

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IPersonasNaturalesCNegocio
    {
        List<PersonasNaturalesC> Consultar();
        PersonasNaturalesC Guardar(PersonasNaturalesC entidad);

        PersonasNaturalesC Modificar(PersonasNaturalesC entidad);
        void Borrar(PersonasNaturalesC entidad);
    }
}
