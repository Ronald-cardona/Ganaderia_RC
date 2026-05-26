

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Suplementos
    {
        public int Id { get; set; }  
        public string? Nombre { get; set; }
        public decimal CostoSuplemento { get; set; }
        public decimal CantidadSuplemento { get; set; }
        public DateTime FechaCompraSuplemento { get; set; }

        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")] public Usuarios? _usuario { get; set; }

        [NotMapped] public List<BrindarSuplementos>? brindarSuplemento { get; set; } 
        [NotMapped] public List<Gastos>? gasto { get; set; }
    }
}
