

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class VisitasVeterinarias
    {
        public int Id { get; set; }
        public DateTime FechaVisita { get; set; }
        public int? IdAnimal { get; set; }
        public int? VeterinarioId { get; set; }

        [ForeignKey("IdAnimal")] public Animales? _animal { get; set; }
        [ForeignKey("VeterinarioId")] public Personas? _persona { get; set; }
    }
}
