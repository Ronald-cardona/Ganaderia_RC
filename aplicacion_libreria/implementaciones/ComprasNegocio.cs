

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class ComprasNegocio : IComprasNegocio
    {
        private IConexion? iConexion;

        public List<Compras> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Compras ";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.Compras!.ToList();
        }

        public Compras Guardar(Compras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Compras!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó una nueva Compra";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Compras Modificar(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Compras>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó una  Compra";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Compras entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var compra = this.iConexion.Compras.FirstOrDefault(e => e.Id == entidad.Id);

            if (compra == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Compras.Remove(compra);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró una Compra";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
        }
    }
}
