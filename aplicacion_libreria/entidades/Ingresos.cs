
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Ingresos
    {
        public int Id { get; set; }  // segunda regla
        public DateTime FechaIngreso { get; set; }
        public decimal CantidadIngreso { get; set; }
        public string? DescripcionIngreso { get; set; }


        [NotMapped] public Ventas? venta { get; set; }
    }
}
