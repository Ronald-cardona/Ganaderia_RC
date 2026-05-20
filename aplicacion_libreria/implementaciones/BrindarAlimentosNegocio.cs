using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;


namespace aplicacion_libreria.implementaciones
{
    public class BrindarAlimentosNegocio : IBrindarAlimentosNegocio
    {
        private IConexion? iConexion;

        public List<BrindarAlimentos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Brindar Alimentos";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();

            return this.iConexion.BrindarAlimentos!.ToList();
        }

        public BrindarAlimentos Guardar(BrindarAlimentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.BrindarAlimentos!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó un nuevo Brindado de alimentos";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public BrindarAlimentos Modificar(BrindarAlimentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<BrindarAlimentos>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó un  Brindado de alimentos";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(BrindarAlimentos entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var alimentoBrindado = this.iConexion.BrindarAlimentos.FirstOrDefault(e => e.Id == entidad.Id);

            if (alimentoBrindado == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.BrindarAlimentos.Remove(alimentoBrindado);


            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un Brindado de Alimentos";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
        }
    }
}
