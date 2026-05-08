

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class HistorialPesos
    {
        public int Id { get; set; }  
        public DateTime FechaUltimoPesaje { get; set; }
        public DateTime FechaPesajeActual { get; set; }
        public decimal UltimoPeso { get; set; }
        public decimal PesoActual { get; set; }

        public int AnimalId { get; set; }
        [ForeignKey("AnimalId")] public Animales? _animal { get; set; }
    }
}
// se debe de sacar la ganancia, la ganancia diaria y los dias que van de un pesaje al otro
