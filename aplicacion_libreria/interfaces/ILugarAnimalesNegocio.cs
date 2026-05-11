

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface ILugarAnimalesNegocio
    {
        List<LugarAnimales> Consultar();
        LugarAnimales Guardar(LugarAnimales entidad);

        LugarAnimales Modificar(LugarAnimales entidad);
        void Borrar(LugarAnimales entidad);
    }
}
