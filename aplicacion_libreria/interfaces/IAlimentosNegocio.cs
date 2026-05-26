

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IAlimentosNegocio
    {
        List<Alimentos> Consultar(string correo);
        Alimentos Guardar(Alimentos entidad, string correo);

        Alimentos Modificar(Alimentos entidad);
        void Borrar(Alimentos entidad);
    }
}
