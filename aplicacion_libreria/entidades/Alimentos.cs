

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Alimentos
    {
        public int Id { get; set; }  
        public string? TipoAlimento { get; set; }
        public decimal CostoAlimento { get; set; }
        public decimal CantidadAlimento { get; set; }
        public DateTime FechaCompraAlimento { get; set; }

        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")] public Usuarios? _usuario { get; set; }

        [NotMapped] public List<BrindarAlimentos>? brindarAlimento { get; set; } 
        [NotMapped] public List<Gastos>? gasto { get; set; }
    }
}
