

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IConfiguracionesNegocio
    {
        List<Configuraciones> Consultar(string correo);
        Configuraciones Guardar(Configuraciones entidad, string correo);

        Configuraciones Modificar(Configuraciones entidad);
        void Borrar(Configuraciones entidad);
    }
}
