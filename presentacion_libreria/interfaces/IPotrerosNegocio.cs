

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IPotrerosNegocio
    {
        List<Potreros> Consultar();
        Potreros Guardar(Potreros entidad);
        Potreros Modificar(Potreros entidad);
        Potreros Borrar(Potreros entidad);
    }
}
