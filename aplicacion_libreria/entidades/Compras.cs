

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Compras
    {
        public int Id { get; set; }  // segunda regla
        public DateTime FechaCompra { get; set; }
        public decimal PesoCompra { get; set; }
        public decimal PrecioKiloCompra { get; set; }  //precio del kilo
        public string? DescripcionCompra { get; set; }

        public int ProveedorId { get; set; }

        public Gastos? _gasto { get; set; }
        [ForeignKey("ProveedorId")] public Proveedores? _proveedor { get; set; }
        [NotMapped] public List<Animales>? _animal { get; set; }
    }
} //calcular compra total
