

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IConfiguracionesNegocio
    {
        List<Configuraciones> Consultar();
        Configuraciones Guardar(Configuraciones entidad);
        Configuraciones Modificar(Configuraciones entidad);
        Configuraciones Borrar(Configuraciones entidad);
    }
}
