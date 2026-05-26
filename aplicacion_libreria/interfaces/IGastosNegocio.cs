

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IGastosNegocio
    {
        List<Gastos> Consultar(string correo);
        Gastos Guardar(Gastos entidad, string correo);

        Gastos Modificar(Gastos entidad);
        void Borrar(Gastos entidad);
    }
}
