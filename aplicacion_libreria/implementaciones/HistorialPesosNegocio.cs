
using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class HistorialPesosNegocio : IHistorialPesosNegocio
    {
        private IConexion? iConexion;

        public List<HistorialPesos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.HistorialPesos!.ToList();
        }

        public HistorialPesos Guardar(HistorialPesos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.HistorialPesos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public HistorialPesos Modificar(HistorialPesos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<HistorialPesos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(HistorialPesos entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var historialPeso = this.iConexion.HistorialPesos.FirstOrDefault(e => e.Id == entidad.Id);

            if (historialPeso == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.HistorialPesos.Remove(historialPeso);
            this.iConexion.SaveChanges();
        }
    }
}
