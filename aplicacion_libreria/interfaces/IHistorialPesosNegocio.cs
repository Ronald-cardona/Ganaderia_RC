

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IHistorialPesosNegocio
    {
        List<HistorialPesos> Consultar();
        HistorialPesos Guardar(HistorialPesos entidad);

        HistorialPesos Modificar(HistorialPesos entidad);
        void Borrar(HistorialPesos entidad);

         byte[] GenerarReporte(int IdAnimal);
    }
}
