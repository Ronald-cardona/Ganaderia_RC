
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class BrindarSuplementos
    {
        public int Id { get; set; }
        public DateTime FechaBrindarSuplemetos { get; set; }
        public int? IdAnimal { get; set; }
        public int? SuplementoId { get; set; }

        [ForeignKey("IdAnimal")] public Animales? _animal { get; set; }
        [ForeignKey("SuplementoId")] public Suplementos? _suplemento { get; set; }
    }
}
