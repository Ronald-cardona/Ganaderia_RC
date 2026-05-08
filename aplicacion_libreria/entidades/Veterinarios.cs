

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Veterinarios
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }

        [ForeignKey("IdPersona")] public Personas? _persona { get; set; }

        [NotMapped] public List<VisitasVeterinarias>? visitaVeterinaria { get; set; }
    }
}
