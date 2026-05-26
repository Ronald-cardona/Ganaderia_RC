

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Clientes
    {
        public int Id { get; set; }  
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")] public Usuarios? _usuario { get; set; }


        [NotMapped] public List<Ventas>? ventas { get; set; }
        [NotMapped] public List<PersonasNaturalesC>? PersonasNaturalesC { get; set; }
        [NotMapped] public List<SubastasC>? SubastasC { get; set; }
    }
}
