

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IBrindarAlimentosNegocio
    {
        List<BrindarAlimentos> Consultar();
        BrindarAlimentos Guardar(BrindarAlimentos entidad);
        BrindarAlimentos Modificar(BrindarAlimentos entidad);
        BrindarAlimentos Borrar(BrindarAlimentos entidad);
    }
}
