

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IAnimalesNegocio
    {
        List<Animales> Consultar();
        Animales Guardar(Animales entidad);
        Animales Modificar(Animales entidad);
        Animales Borrar(Animales entidad);
    }
}
