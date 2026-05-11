

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class IngresosNegocio : IIngresosNegocio
    {
        private IConexion? iConexion;

        public List<Ingresos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Ingresos!.ToList();
        }

        public Ingresos Guardar(Ingresos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Ingresos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Ingresos Modificar(Ingresos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Ingresos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Ingresos entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var ingreso = this.iConexion.Ingresos.FirstOrDefault(e => e.Id == entidad.Id);

            if (ingreso == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Ingresos.Remove(ingreso);
            this.iConexion.SaveChanges();
        }
    }
}
