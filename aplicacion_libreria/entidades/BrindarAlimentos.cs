
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class BrindarAlimentos
    {
        public int Id { get; set; }
     public DateTime FechaBrindarAlimentos {get; set;} 
     public int? IdAnimal { get; set;}
     public int? AlimentoId {get; set;}
        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")] public Usuarios? _usuario { get; set; }

        [ForeignKey("IdAnimal")] public Animales? _animal { get; set; }
        [ForeignKey("AlimentoId")] public Alimentos? _alimento { get; set; }
    }
}
