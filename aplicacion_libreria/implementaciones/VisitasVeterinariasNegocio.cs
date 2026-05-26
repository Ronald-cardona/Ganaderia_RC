using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;



namespace aplicacion_libreria.implementaciones
{
    public class VisitasVeterinariasNegocio : IVisitasVeterinariasNegocio
    {
        private IConexion? iConexion;

        public List<VisitasVeterinarias> Consultar(string correo)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Visitas Veterinarias";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.VisitasVeterinarias!.Where(x => x._usuario!.Correo == correo) //filtrar por correo para que solo el usuario vea
            .Include(x => x._persona)
            .Include(x => x._animal)
            .ToList();
        }

        public VisitasVeterinarias Guardar(VisitasVeterinarias entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para que pueda guardar por usuario
            var usuario = this.iConexion.Usuarios!.First(x => x.Correo == correo);
            entidad.UsuarioId = usuario.Id;

            this.iConexion.VisitasVeterinarias!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó una nueva Visita Veterinaria";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
            return entidad;
        }

        public VisitasVeterinarias Modificar(VisitasVeterinarias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para saber cual animal modificar respecto al usuario 
            var visitasvBd = this.iConexion.VisitasVeterinarias!.First(x => x.Id == entidad.Id);
            entidad.UsuarioId = visitasvBd.UsuarioId;

            var entry = this.iConexion!.Entry<VisitasVeterinarias>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó una Visita Veterinaria";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(VisitasVeterinarias entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var Visita = this.iConexion.VisitasVeterinarias.FirstOrDefault(e => e.Id == entidad.Id);

            if (Visita == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.VisitasVeterinarias.Remove(Visita);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró una Visita Veterinaria";
            this.iConexion.Auditorias!.Add(auditorias);


            this.iConexion.SaveChanges();
        }
    }
}
