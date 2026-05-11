
using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IBrindarAlimentosNegocio
    {
        List<BrindarAlimentos> Consultar();
        BrindarAlimentos Guardar(BrindarAlimentos entidad);

        BrindarAlimentos Modificar(BrindarAlimentos entidad);
        void Borrar(BrindarAlimentos entidad);
    }
}
