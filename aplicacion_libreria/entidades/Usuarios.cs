
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }  
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
        public DateTime fecha { get; set; }

        [NotMapped] public List<Roles>? Roles { get; set; }

        public Configuraciones? _configuracion { get; set; }
    }
}
