

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IAlimentosNegocio
    {
        List<Alimentos> Consultar(string correo);
        Alimentos Guardar(Alimentos entidad, string correo);
        Alimentos Modificar(Alimentos entidad);
        Alimentos Borrar(Alimentos entidad);
    }
}
