

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class VacunasNegocio : IVacunasNegocio
    {
        private IConexion? iConexion;

        public List<Vacunas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Vacunas!.ToList();
        }

        public Vacunas Guardar(Vacunas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Vacunas!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Vacunas Modificar(Vacunas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Vacunas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Vacunas entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var vacuna = this.iConexion.Vacunas.FirstOrDefault(e => e.Id == entidad.Id);

            if (vacuna == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Vacunas.Remove(vacuna);
            this.iConexion.SaveChanges();
        }
    }
}
