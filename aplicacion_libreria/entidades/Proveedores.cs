
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Proveedores
    {
        public int Id { get; set; }  
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        [NotMapped] public List<Compras>? Compras { get; set; }
        [NotMapped] public List<PersonasNaturalesP>? PersonasNaturalesP { get; set; }
        [NotMapped] public List<SubastasP>? SubastasP { get; set; }
    }
}
