using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class ConfiguracionesNegocio : IConfiguracionesNegocio
    {
        private IConexion? iConexion;

        public List<Configuraciones> Consultar(string correo)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Configuraciones";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();


            return this.iConexion.Configuraciones!.Where(x => x._usuario!.Correo == correo) //filtrar por correo para que solo el usuario vea sus animales 
           .Include(x => x._usuario)
           .ToList();
        }

        public Configuraciones Guardar(Configuraciones entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para que pueda guardar por usuario
            var usuario = this.iConexion.Usuarios!.First(x => x.Correo == correo);
            entidad.UsuarioId = usuario.Id;

            this.iConexion.Configuraciones!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó una nueva Configuracion ";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Configuraciones Modificar(Configuraciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para saber cual animal modificar respecto al usuario 
            var configuracionBd = this.iConexion.Configuraciones!.First(x => x.Id == entidad.Id);
            entidad.UsuarioId = configuracionBd.UsuarioId;

            var entry = this.iConexion!.Entry<Configuraciones>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó una  Configuracion ";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Configuraciones entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var configuracion = this.iConexion.Configuraciones.FirstOrDefault(e => e.Id == entidad.Id);

            if (configuracion == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Configuraciones.Remove(configuracion);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró una Configuracion";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
        }
    }
}
