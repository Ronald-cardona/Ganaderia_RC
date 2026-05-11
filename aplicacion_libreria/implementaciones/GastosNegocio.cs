

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class GastosNegocio :IGastosNegocio
    {
        private IConexion? iConexion;

        public List<Gastos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Gastos!.ToList();
        }

        public Gastos Guardar(Gastos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Gastos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Gastos Modificar(Gastos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Gastos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Gastos entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var gasto = this.iConexion.Gastos.FirstOrDefault(e => e.Id == entidad.Id);

            if (gasto == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Gastos.Remove(gasto);
            this.iConexion.SaveChanges();
        }
    }
}
