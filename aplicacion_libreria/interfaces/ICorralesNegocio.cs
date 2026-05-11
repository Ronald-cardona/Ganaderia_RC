

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface ICorralesNegocio
    {
        List<Corrales> Consultar();
        Corrales Guardar(Corrales entidad);

        Corrales Modificar(Corrales entidad);
        void Borrar(Corrales entidad);
    }
}
