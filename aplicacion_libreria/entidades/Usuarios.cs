
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }  
        
        public string Correo { get; set; }
       
        public string Contraseña { get; set; }
        

        [NotMapped] public List<Roles>? Roles { get; set; }

        [NotMapped] public Configuraciones? _configuracion { get; set; }
    }
}
