

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IGastosNegocio
    {
        List<Gastos> Consultar();
        Gastos Guardar(Gastos entidad);
        Gastos Modificar(Gastos entidad);
        Gastos Borrar(Gastos entidad);
    }
}
