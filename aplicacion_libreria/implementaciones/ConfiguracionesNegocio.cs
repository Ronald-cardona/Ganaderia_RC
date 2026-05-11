using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class ConfiguracionesNegocio : IConfiguracionesNegocio
    {
        private IConexion? iConexion;

        public List<Configuraciones> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Configuraciones!.ToList();
        }

        public Configuraciones Guardar(Configuraciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Configuraciones!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Configuraciones Modificar(Configuraciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Configuraciones>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Configuraciones entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var configuracion = this.iConexion.Configuraciones.FirstOrDefault(e => e.Id == entidad.Id);

            if (configuracion == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Configuraciones.Remove(configuracion);
            this.iConexion.SaveChanges();
        }
    }
}
