

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Roles  
    {
        public int Id { get; set; }

        public string Tipo { get; set; }

        public int RolUsuario { get; set; }
        [ForeignKey("RolUsuario")] public Usuarios? _usuario { get; set; }

    }
}
