
using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IIngresosNegocio
    {
        List<Ingresos> Consultar(string correo);
        Ingresos Guardar(Ingresos entidad, string correo);
        Ingresos Modificar(Ingresos entidad);
        Ingresos Borrar(Ingresos entidad);
    }
}
