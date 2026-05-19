
using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IIngresosNegocio
    {
        List<Ingresos> Consultar();
        Ingresos Guardar(Ingresos entidad);
        Ingresos Modificar(Ingresos entidad);
        Ingresos Borrar(Ingresos entidad);
    }
}
