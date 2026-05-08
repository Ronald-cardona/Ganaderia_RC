

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class VisitasVeterinarias
    {
        public int Id { get; set; }
        public DateTime FechaVisita { get; set; }
        public int? AnimalId { get; set; }
        public int? VeterinarioId { get; set; }

        [ForeignKey("AnimalId")] public Animales? _animal { get; set; }
        [ForeignKey("AnimalId")] public Veterinarios? _veterinario { get; set; }
    }
}
