

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IHistorialPesosNegocio
    {
        List<HistorialPesos> Consultar(string correo);
        HistorialPesos Guardar(HistorialPesos entidad, string correo);

        HistorialPesos Modificar(HistorialPesos entidad);
        void Borrar(HistorialPesos entidad);

         byte[] GenerarReporte(int IdAnimal);
    }
}
