
using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IIngresosNegocio
    {
        List<Ingresos> Consultar();
        Ingresos Guardar(Ingresos entidad);

        Ingresos Modificar(Ingresos entidad);
        void Borrar(Ingresos entidad);

    }
}
