

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IHistorialPesosNegocio
    {
        List<HistorialPesos> Consultar(string correo);
        HistorialPesos Guardar(HistorialPesos entidad, string correo);
        HistorialPesos Modificar(HistorialPesos entidad);
        HistorialPesos Borrar(HistorialPesos entidad);
    }
}
