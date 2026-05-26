

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IGastosNegocio
    {
        List<Gastos> Consultar(string correo);
        Gastos Guardar(Gastos entidad, string correo);
        Gastos Modificar(Gastos entidad);
        Gastos Borrar(Gastos entidad);
    }
}
