

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IConfiguracionesNegocio
    {
        List<Configuraciones> Consultar();
        Configuraciones Guardar(Configuraciones entidad);

        Configuraciones Modificar(Configuraciones entidad);
        void Borrar(Configuraciones entidad);
    }
}
