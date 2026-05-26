

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IAnimalesNegocio
    {
        List<Animales> Consultar(string correo);
        Animales Guardar(Animales entidad, string correo);
        Animales Modificar(Animales entidad);
        Animales Borrar(Animales entidad);
    }
}
