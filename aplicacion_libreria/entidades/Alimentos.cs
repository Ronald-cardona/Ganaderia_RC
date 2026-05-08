

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Alimentos
    {
        public int Id { get; set; }  
        public string? TipoAlimento { get; set; }
        public decimal CostoAlimento { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaCompraAlimentos { get; set; }

        [NotMapped] public List<BrindarAlimentos>? brindarAlimento { get; set; } 
        [NotMapped] public List<Gastos>? gasto { get; set; }
    }
}
