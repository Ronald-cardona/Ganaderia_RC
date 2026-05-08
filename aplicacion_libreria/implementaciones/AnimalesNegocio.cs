
using aplicacion_libreria.nucleo;
using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class AnimalesNegocio : IAnimalesNegocio
    {
        private IConexion? iConexion;

        public List<Animales> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Animales!.ToList();
        }

        public Animales Guardar(Animales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Animales!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Animales Modificar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Animales>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Animales entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var animal = this.iConexion.Animales.FirstOrDefault(e => e.Id == entidad.Id);

            if (animal == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Animales.Remove(animal);
            this.iConexion.SaveChanges();
        }
    }
}
