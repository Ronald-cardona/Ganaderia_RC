
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class PersonasNaturalesP
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }

        public string Cedula { get; set; }
        [ForeignKey("IdProveedor")] public Proveedores? _proveedor { get; set; }
    }
}
