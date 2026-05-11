

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class VeterinariosNegocio : IVeterinariosNegocio
    {
        private IConexion? iConexion;

        public List<Veterinarios> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Veterinarios!.ToList();
        }

        public Veterinarios Guardar(Veterinarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Veterinarios!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Veterinarios Modificar(Veterinarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Veterinarios>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Veterinarios entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var veterinario = this.iConexion.Veterinarios.FirstOrDefault(e => e.Id == entidad.Id);

            if (veterinario == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Veterinarios.Remove(veterinario);
            this.iConexion.SaveChanges();
        }
    }
}
