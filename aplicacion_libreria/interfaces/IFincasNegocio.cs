using aplicacion_libreria.entidades;


namespace aplicacion_libreria.interfaces
{
    public interface IFincasNegocio
    {
        List<Fincas> Consultar();
        Fincas Guardar(Fincas entidad);

        Fincas Modificar(Fincas entidad);
        void Borrar(Fincas entidad);
    }
}
