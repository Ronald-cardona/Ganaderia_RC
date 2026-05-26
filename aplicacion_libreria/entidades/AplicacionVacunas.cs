

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class AplicacionVacunas
    {
        public int Id { get; set; }
        public DateTime FechaAplicacion { get; set; }

        public int IdAnimal { get; set; }
        public int? VacunaId { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")] public Usuarios? _usuario { get; set; }

        [ForeignKey("IdAnimal")] public Animales? _animal { get; set; }
        [ForeignKey("VacunaId")] public Vacunas? _vacuna { get; set; }
    }
}
