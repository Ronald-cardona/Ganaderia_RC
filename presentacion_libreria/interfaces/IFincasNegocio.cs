

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IFincasNegocio
    {
        List<Fincas> Consultar();
        Fincas Guardar(Fincas entidad);
        Fincas Modificar(Fincas entidad);
        Fincas Borrar(Fincas entidad);
    }
}
