

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IPotrerosNegocio
    {
        List<Potreros> Consultar();
        Potreros Guardar(Potreros entidad);

        Potreros Modificar(Potreros entidad);
        void Borrar(Potreros entidad);
    }
}
