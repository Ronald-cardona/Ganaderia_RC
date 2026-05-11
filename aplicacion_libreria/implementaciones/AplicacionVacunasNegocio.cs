

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class AplicacionVacunasNegocio : IAplicacionVacunasNegocio
    {
        private IConexion? iConexion;

        public List<AplicacionVacunas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.AplicacionVacunas!.ToList();
        }

        public AplicacionVacunas Guardar(AplicacionVacunas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.AplicacionVacunas!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public AplicacionVacunas Modificar(AplicacionVacunas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<AplicacionVacunas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(AplicacionVacunas entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var vacunaAplicada = this.iConexion.AplicacionVacunas.FirstOrDefault(e => e.Id == entidad.Id);

            if (vacunaAplicada == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.AplicacionVacunas.Remove(vacunaAplicada);
            this.iConexion.SaveChanges();
        }
    }
}
