

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class UsuariosNegocio : IUsuariosNegocio
    {
        private IConexion? iConexion;

        public List<Usuarios> Consultar()
        {
           
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Usuarios";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();

            return this.iConexion.Usuarios!.ToList(); //realizar los roles
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Usuarios!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó un nuevo usuario";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó un usuario";
            this.iConexion.Auditorias!.Add(auditorias);



            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Usuarios entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var usuario = this.iConexion.Usuarios.FirstOrDefault(e => e.Id == entidad.Id);

            if (usuario == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Usuarios.Remove(usuario);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un usuario";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
        }

        //login de usuarios 
        public Usuarios? Login(string correo, string contraseña)
           
        {
            this.iConexion = new Conexion();

            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");
            

            return this.iConexion.Usuarios!.Include(x => x._rol).FirstOrDefault(x =>
                    x.Correo == correo &&
                    x.Contraseña == contraseña);
        }

    }
}
