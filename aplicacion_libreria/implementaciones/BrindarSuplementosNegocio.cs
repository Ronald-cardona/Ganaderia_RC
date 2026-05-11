
using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class BrindarSuplementosNegocio : IBrindarSuplementosNegocio
    {
        private IConexion? iConexion;

        public List<BrindarSuplementos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.BrindarSuplementos!.ToList();
        }

        public BrindarSuplementos Guardar(BrindarSuplementos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.BrindarSuplementos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public BrindarSuplementos Modificar(BrindarSuplementos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<BrindarSuplementos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(BrindarSuplementos entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var suplementoBrindado = this.iConexion.BrindarSuplementos.FirstOrDefault(e => e.Id == entidad.Id);

            if (suplementoBrindado == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.BrindarSuplementos.Remove(suplementoBrindado);
            this.iConexion.SaveChanges();
        }
    }
}
