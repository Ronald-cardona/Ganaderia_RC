

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IBrindarSuplementosNegocio
    {
        List<BrindarSuplementos> Consultar();
        BrindarSuplementos Guardar(BrindarSuplementos entidad);
        BrindarSuplementos Modificar(BrindarSuplementos entidad);
        BrindarSuplementos Borrar(BrindarSuplementos entidad);
    }
}
