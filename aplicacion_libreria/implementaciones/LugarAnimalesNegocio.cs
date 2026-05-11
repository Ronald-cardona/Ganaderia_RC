
using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class LugarAnimalesNegocio : ILugarAnimalesNegocio
    {
        private IConexion? iConexion;

        public List<LugarAnimales> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.LugarAnimales!.ToList();
        }

        public LugarAnimales Guardar(LugarAnimales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.LugarAnimales!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public LugarAnimales Modificar(LugarAnimales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<LugarAnimales>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(LugarAnimales entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var lugarAnimal = this.iConexion.LugarAnimales.FirstOrDefault(e => e.Id == entidad.Id);

            if (lugarAnimal == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.LugarAnimales.Remove(lugarAnimal);
            this.iConexion.SaveChanges();
        }
    }
}
