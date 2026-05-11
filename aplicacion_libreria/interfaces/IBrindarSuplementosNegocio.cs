

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IBrindarSuplementosNegocio
    {
        List<BrindarSuplementos> Consultar();
        BrindarSuplementos Guardar(BrindarSuplementos entidad);

        BrindarSuplementos Modificar(BrindarSuplementos entidad);
        void Borrar(BrindarSuplementos entidad);
    }
}
