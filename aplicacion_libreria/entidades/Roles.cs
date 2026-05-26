

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Roles  
    {
        public int Id { get; set; }

        public string Tipo { get; set; }

        


        [NotMapped] public List<Usuarios>? Usuarios { get; set; }

    }
}
