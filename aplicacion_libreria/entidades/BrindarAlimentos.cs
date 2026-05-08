
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class BrindarAlimentos
    {
        public int Id { get; set; }
     public DateTime FechaBrindarAlimentos {get; set;} 
     public int? AnimalId {get; set;}
     public int? AlimentoId {get; set;}

        [ForeignKey("AnimalId")] public Animales? _animal { get; set; }
        [ForeignKey("AlimentoId")] public Alimentos? _alimento { get; set; }
    }
}
