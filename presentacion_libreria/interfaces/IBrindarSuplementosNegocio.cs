

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IBrindarSuplementosNegocio
    {
        List<BrindarSuplementos> Consultar(string correo);
        BrindarSuplementos Guardar(BrindarSuplementos entidad, string correo);
        BrindarSuplementos Modificar(BrindarSuplementos entidad);
        BrindarSuplementos Borrar(BrindarSuplementos entidad);
    }
}
