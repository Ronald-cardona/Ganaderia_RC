
using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IIngresosNegocio
    {
        List<Ingresos> Consultar(string correo);
        Ingresos Guardar(Ingresos entidad, string correo);

        Ingresos Modificar(Ingresos entidad);
        void Borrar(Ingresos entidad);

    }
}
