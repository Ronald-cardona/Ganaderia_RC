

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class GastosNegocio :IGastosNegocio
    {
        private IConexion? iConexion;

        

        public List<Gastos> Consultar(string correo)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Gastos";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.Gastos!.Where(x => x._usuario!.Correo == correo) //filtrar por correo para que solo el usuario vea
           .Include(x => x._alimento)
           .Include(x => x._compra)
           .Include(x => x._vacuna)
           .Include(x => x._suplemento)
           .Include(x => x._persona)
           .ToList();
        }

        public Gastos Guardar(Gastos entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para que pueda guardar por usuario
            var usuario = this.iConexion.Usuarios!.First(x => x.Correo == correo);
            entidad.UsuarioId = usuario.Id;

            this.iConexion.Gastos!.Add(entidad!);

            
            

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó un nuevo Gasto";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
            return entidad;
        }

        public Gastos Modificar(Gastos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para saber cual animal modificar respecto al usuario 
            var gastoBd = this.iConexion.Gastos!.First(x => x.Id == entidad.Id);
            entidad.UsuarioId = gastoBd.UsuarioId;

            var entry = this.iConexion!.Entry<Gastos>(entidad);
            entry.State = EntityState.Modified;

            

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó un  Gasto";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Gastos entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var gasto = this.iConexion.Gastos.FirstOrDefault(e => e.Id == entidad.Id);

            if (gasto == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Gastos.Remove(gasto);


            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un usuario";
            this.iConexion.Auditorias!.Add(auditorias);



            this.iConexion.SaveChanges();
        }






    }
}
