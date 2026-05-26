
using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IBrindarAlimentosNegocio
    {
        List<BrindarAlimentos> Consultar(string correo);
        BrindarAlimentos Guardar(BrindarAlimentos entidad, string correo);

        BrindarAlimentos Modificar(BrindarAlimentos entidad);
        void Borrar(BrindarAlimentos entidad);
    }
}
