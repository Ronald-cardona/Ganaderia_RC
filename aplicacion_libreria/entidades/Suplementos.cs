

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Suplementos
    {
        public int Id { get; set; }  
        public string? Nombre { get; set; }
        public decimal CostoSuplemento { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaCompraSuplemeto { get; set; }

       
        [NotMapped] public List<BrindarSuplementos>? brindarSuplemento { get; set; } 
        [NotMapped] public List<Gastos>? gasto { get; set; }
    }
}
