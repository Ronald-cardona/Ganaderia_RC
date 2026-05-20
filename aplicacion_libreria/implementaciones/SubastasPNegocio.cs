

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class SubastasPNegocio : ISubastasPNegocio
    {
        private IConexion? iConexion;

        public List<SubastasP> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Subastas Proveedor ";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.SubastasP!.ToList();
        }

        public SubastasP Guardar(SubastasP entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.SubastasP!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó una nueva Subasta de Proveedor";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public SubastasP Modificar(SubastasP entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<SubastasP>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó una Subasta de Proveedor";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(SubastasP entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var subastaP = this.iConexion.SubastasP.FirstOrDefault(e => e.Id == entidad.Id);

            if (subastaP == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.SubastasP.Remove(subastaP);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un subasta de Proveedor";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
        }
    }
}
