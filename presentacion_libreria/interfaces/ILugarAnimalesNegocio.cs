

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface ILugarAnimalesNegocio
    {
        List<LugarAnimales> Consultar(string correo);
        LugarAnimales Guardar(LugarAnimales entidad, string correo);
        LugarAnimales Modificar(LugarAnimales entidad);
        LugarAnimales Borrar(LugarAnimales entidad);
    }
}
