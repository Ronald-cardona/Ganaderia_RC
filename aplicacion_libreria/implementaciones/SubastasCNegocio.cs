

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class SubastasCNegocio : ISubastasCNegocio
    {
        private IConexion? iConexion;

        public List<SubastasC> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Subastas Clientes";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.SubastasC!.ToList();
        }

        public SubastasC Guardar(SubastasC entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.SubastasC!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó una nueva Subasta de Cliente";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
            return entidad;
        }

        public SubastasC Modificar(SubastasC entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<SubastasC>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó una Subasta de Cliente";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(SubastasC entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var subastaC = this.iConexion.SubastasC.FirstOrDefault(e => e.Id == entidad.Id);

            if (subastaC == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.SubastasC.Remove(subastaC);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró una Subasta de Cliente";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
        }
    }
}
