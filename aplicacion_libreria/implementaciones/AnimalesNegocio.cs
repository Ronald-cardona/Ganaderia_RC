
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

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Animales";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();

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

            Auditorias auditorias = new Auditorias();

            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó un nuevo Animal";
            this.iConexion.Auditorias!.Add(auditorias);

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

            Auditorias auditorias = new Auditorias();

            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó un  usuario";
            this.iConexion.Auditorias!.Add(auditorias);

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
            Auditorias auditorias = new Auditorias();

            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un Animal";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
        }
    }
}
