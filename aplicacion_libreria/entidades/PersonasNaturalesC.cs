

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class PersonasNaturalesC
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }

        public string Cedula { get; set; }
        [ForeignKey("IdCliente")] public Clientes? _cliente { get; set; }
    }
}
