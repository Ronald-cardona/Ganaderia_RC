using aplicacion_libreria.entidades;



namespace aplicacion_libreria.interfaces
{
    public interface IAnimalesNegocio
    {
        List<Animales> Consultar(string correo);
        Animales Guardar(Animales entidad, string correo);

        Animales Modificar(Animales entidad);
        void Borrar(Animales entidad);

        byte[] GenerarReporte(int Id);
    }
}
