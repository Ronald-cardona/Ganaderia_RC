

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IAlimentosNegocio
    {
        List<Alimentos> Consultar();
        Alimentos Guardar(Alimentos entidad);

        Alimentos Modificar(Alimentos entidad);
        void Borrar(Alimentos entidad);
    }
}
