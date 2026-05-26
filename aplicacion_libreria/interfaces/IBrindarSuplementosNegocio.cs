

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IBrindarSuplementosNegocio
    {
        List<BrindarSuplementos> Consultar(string correo);
        BrindarSuplementos Guardar(BrindarSuplementos entidad, string correo);

        BrindarSuplementos Modificar(BrindarSuplementos entidad);
        void Borrar(BrindarSuplementos entidad);
    }
}
