

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

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Aplicacion de vacunas";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();

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

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó un nueva Aplicacion de vacuna";
            this.iConexion.Auditorias!.Add(auditorias);

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

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó una  Aplicacion de vacuna";
            this.iConexion.Auditorias!.Add(auditorias);

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

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un usuario";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();
        }
    }
}
