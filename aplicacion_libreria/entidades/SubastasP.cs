

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class SubastasP
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        [ForeignKey("IdProveedor")] public Proveedores? _proveedor { get; set; }
    }
}
