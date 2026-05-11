

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class EstadosNegocio : IEstadosNegocio
    {
        private IConexion? iConexion;

        public List<Estados> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Estados!.ToList();
        }

        public Estados Guardar(Estados entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Estados!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Estados Modificar(Estados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Estados>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Estados entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var estado = this.iConexion.Estados.FirstOrDefault(e => e.Id == entidad.Id);

            if (estado == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Estados.Remove(estado);
            this.iConexion.SaveChanges();
        }
    }
}
