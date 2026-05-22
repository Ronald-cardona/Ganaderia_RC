

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Ventas
    {
        public int Id { get; set; }  // segunda regla
        public DateTime FechaVenta { get; set; }
        public decimal PesoFinal { get; set; }
        public decimal PrecioKilo { get; set; }  //precio del kilo

        public decimal? VentaTotal { get; set; }

        public string DescripcionVenta { get; set; }

        public int? IngresoId { get; set; }
        public int ClienteId { get; set; }
        [ForeignKey("IngresoId")] public Ingresos? _ingreso { get; set; }
        [ForeignKey("ClienteId")] public Clientes? _cliente { get; set; }

        [NotMapped] public List<Animales>? animal { get; set; }
    }
} //calcular el total de la venta 
