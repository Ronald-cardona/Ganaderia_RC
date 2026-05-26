

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface ILugarAnimalesNegocio
    {
        List<LugarAnimales> Consultar(string correo);
        LugarAnimales Guardar(LugarAnimales entidad, string correo);

        LugarAnimales Modificar(LugarAnimales entidad);
        void Borrar(LugarAnimales entidad);
    }
}
