using aplicacion_libreria.entidades;



namespace aplicacion_libreria.interfaces
{
    public interface IAnimalesNegocio
    {
        List<Animales> Consultar();
        Animales Guardar(Animales entidad);

        Animales Modificar(Animales entidad);
        void Borrar(Animales entidad);

        byte[] GenerarReporte(int Id);
    }
}
