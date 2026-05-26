

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class AlimentosNegocio : IAlimentosNegocio
    {
        private IConexion? iConexion;

        public List<Alimentos> Consultar(string correo)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Alimentos";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();

            return this.iConexion.Alimentos!.Where(x => x._usuario!.Correo == correo).ToList(); //filtrar por correo para que solo el usuario vea
        } 

        public Alimentos Guardar(Alimentos entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para que pueda guardar por usuario
            var usuario = this.iConexion.Usuarios!.First(x => x.Correo == correo);
            entidad.UsuarioId = usuario.Id;

            this.iConexion.Alimentos!.Add(entidad!);

            Auditorias auditorias = new Auditorias();

            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se guardó un nuevo alimento";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Alimentos Modificar(Alimentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para saber cual animal modificar respecto al usuario 
            var alimentoBd = this.iConexion.Alimentos!.First(x => x.Id == entidad.Id);
            entidad.UsuarioId = alimentoBd.UsuarioId;

            var entry = this.iConexion!.Entry<Alimentos>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();

            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó un nuevo Alimento";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Alimentos entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var alimento = this.iConexion.Alimentos.FirstOrDefault(e => e.Id == entidad.Id);

            if (alimento == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Alimentos.Remove(alimento);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un Alimento";
            this.iConexion.Auditorias!.Add(auditorias);
            

            this.iConexion.SaveChanges();
        }
    }
}
