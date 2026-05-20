

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class PersonasNaturalesCNegocio : IPersonasNaturalesCNegocio
    {
        private IConexion? iConexion;

        public List<PersonasNaturalesC> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Personas naturales CLIENTES";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.PersonasNaturalesC!.ToList();
        }

        public PersonasNaturalesC Guardar(PersonasNaturalesC entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.PersonasNaturalesC!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó una nueva Persona natural CLIENTE";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public PersonasNaturalesC Modificar(PersonasNaturalesC entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<PersonasNaturalesC>(entidad);
            entry.State = EntityState.Modified;


            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó una Persona natural CLIENTE";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(PersonasNaturalesC entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var personaNaturalC = this.iConexion.PersonasNaturalesC.FirstOrDefault(e => e.Id == entidad.Id);

            if (personaNaturalC == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.PersonasNaturalesC.Remove(personaNaturalC);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró una Persona natural CLIENTE";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
        }
    }
}
