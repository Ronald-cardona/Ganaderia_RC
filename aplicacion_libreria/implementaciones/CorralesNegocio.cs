

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class CorralesNegocio : ICorralesNegocio
    {
        private IConexion? iConexion;

        public List<Corrales> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Corrales!.ToList();
        }

        public Corrales Guardar(Corrales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Corrales!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Corrales Modificar(Corrales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Corrales>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Corrales entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var corral = this.iConexion.Corrales.FirstOrDefault(e => e.Id == entidad.Id);

            if (corral == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Corrales.Remove(corral);
            this.iConexion.SaveChanges();
        }
    }
}
