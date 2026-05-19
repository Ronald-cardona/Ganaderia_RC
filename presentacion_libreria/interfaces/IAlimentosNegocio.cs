

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IAlimentosNegocio
    {
        List<Alimentos> Consultar();
        Alimentos Guardar(Alimentos entidad);
        Alimentos Modificar(Alimentos entidad);
        Alimentos Borrar(Alimentos entidad);
    }
}
