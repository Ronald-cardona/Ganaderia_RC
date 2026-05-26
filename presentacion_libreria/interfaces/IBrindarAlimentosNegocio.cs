

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IBrindarAlimentosNegocio
    {
        List<BrindarAlimentos> Consultar(string correo);
        BrindarAlimentos Guardar(BrindarAlimentos entidad, string correo);
        BrindarAlimentos Modificar(BrindarAlimentos entidad);
        BrindarAlimentos Borrar(BrindarAlimentos entidad);
    }
}
