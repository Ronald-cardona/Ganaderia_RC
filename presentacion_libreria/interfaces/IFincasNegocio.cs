

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IFincasNegocio
    {
        List<Fincas> Consultar(string correo);
        Fincas Guardar(Fincas entidad, string correo);
        Fincas Modificar(Fincas entidad);
        Fincas Borrar(Fincas entidad);
    }
}
