

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class LotesNegocio : ILotesNegocio
    {
        private IConexion? iConexion;

        public List<Lotes> Consultar(string correo)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Lotes";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.Lotes!.Where(x => x._usuario!.Correo == correo).ToList(); //filtrar por correo para que solo el usuario vea sus animales 
        }

        public Lotes Guardar(Lotes entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para que pueda guardar por usuario
            var usuario = this.iConexion.Usuarios!.First(x => x.Correo == correo);
            entidad.UsuarioId = usuario.Id;

            this.iConexion.Lotes!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se guardó un nuevo Lote";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Lotes Modificar(Lotes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para saber cual animal modificar respecto al usuario 
            var loteBd = this.iConexion.Lotes!.First(x => x.Id == entidad.Id);
            entidad.UsuarioId = loteBd.UsuarioId;

            var entry = this.iConexion!.Entry<Lotes>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó un Lote";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Lotes entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var lote = this.iConexion.Lotes.FirstOrDefault(e => e.Id == entidad.Id);

            if (lote == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Lotes.Remove(lote);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un Lote";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
        }
    }
}
