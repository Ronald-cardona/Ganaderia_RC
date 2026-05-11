using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;



namespace aplicacion_libreria.implementaciones
{
    public class VisitasVeterinariasNegocio : IVisitasVeterinariasNegocio
    {
        private IConexion? iConexion;

        public List<VisitasVeterinarias> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.VisitasVeterinarias!.ToList();
        }

        public VisitasVeterinarias Guardar(VisitasVeterinarias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.VisitasVeterinarias!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public VisitasVeterinarias Modificar(VisitasVeterinarias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<VisitasVeterinarias>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(VisitasVeterinarias entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var Visita = this.iConexion.VisitasVeterinarias.FirstOrDefault(e => e.Id == entidad.Id);

            if (Visita == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.VisitasVeterinarias.Remove(Visita);
            this.iConexion.SaveChanges();
        }
    }
}
