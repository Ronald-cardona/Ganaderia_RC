

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class PersonasNaturalesPNegocio : IPersonasNaturalesPNegocio
    {
        private IConexion? iConexion;

        public List<PersonasNaturalesP> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Personas Naturales PROVEEDOR";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.PersonasNaturalesP!.ToList();
        }

        public PersonasNaturalesP Guardar(PersonasNaturalesP entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.PersonasNaturalesP!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó un nueva Persona Natural PROVEEDOR";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
            return entidad;
        }

        public PersonasNaturalesP Modificar(PersonasNaturalesP entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<PersonasNaturalesP>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó una Persona Natural PROVEEDOR";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(PersonasNaturalesP entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var personaNaturalP = this.iConexion.PersonasNaturalesP.FirstOrDefault(e => e.Id == entidad.Id);

            if (personaNaturalP == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.PersonasNaturalesP.Remove(personaNaturalP);


            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró una Persona natural PROVEEDOR";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
        }
    }
}
