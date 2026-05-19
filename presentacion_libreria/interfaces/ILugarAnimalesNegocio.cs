

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface ILugarAnimalesNegocio
    {
        List<LugarAnimales> Consultar();
        LugarAnimales Guardar(LugarAnimales entidad);
        LugarAnimales Modificar(LugarAnimales entidad);
        LugarAnimales Borrar(LugarAnimales entidad);
    }
}
