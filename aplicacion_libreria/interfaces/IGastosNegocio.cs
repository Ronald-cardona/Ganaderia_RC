

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IGastosNegocio
    {
        List<Gastos> Consultar();
        Gastos Guardar(Gastos entidad);

        Gastos Modificar(Gastos entidad);
        void Borrar(Gastos entidad);
    }
}
