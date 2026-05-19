

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IHistorialPesosNegocio
    {
        List<HistorialPesos> Consultar();
        HistorialPesos Guardar(HistorialPesos entidad);
        HistorialPesos Modificar(HistorialPesos entidad);
        HistorialPesos Borrar(HistorialPesos entidad);
    }
}
