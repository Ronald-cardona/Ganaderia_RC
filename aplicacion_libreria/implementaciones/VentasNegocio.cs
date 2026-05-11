

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class VentasNegocio : IVentasNegocio
    {
        private IConexion? iConexion;

        public List<Ventas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Ventas!.ToList();
        }

        public Ventas Guardar(Ventas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Ventas!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Ventas Modificar(Ventas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Ventas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Ventas entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var venta = this.iConexion.Ventas.FirstOrDefault(e => e.Id == entidad.Id);

            if (venta == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Ventas.Remove(venta);
            this.iConexion.SaveChanges();
        }
    }
}
