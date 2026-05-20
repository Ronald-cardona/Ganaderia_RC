

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class SuplementosNegocio : ISuplementosNegocio
    {
        private IConexion? iConexion;

        public List<Suplementos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Suplementos";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();



            return this.iConexion.Suplementos!.ToList();
        }

        public Suplementos Guardar(Suplementos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Suplementos!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó un nuevo Suplemento";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Suplementos Modificar(Suplementos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Suplementos>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó un suplemento";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Suplementos entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var suplemento = this.iConexion.Suplementos.FirstOrDefault(e => e.Id == entidad.Id);

            if (suplemento == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Suplementos.Remove(suplemento);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un Suplemento";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
        }
    }
}
