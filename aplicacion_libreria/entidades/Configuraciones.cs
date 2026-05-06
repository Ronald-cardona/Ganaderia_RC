

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Configuraciones
    {
        public int Id { get; set; }  // segunda regla
        public string Idioma { get; set; }
        public string Moneda { get; set; }
        public bool Tema { get; set; }   //tema oscuro o claro 



        public int UsuarioId { get; set; } //Tercera regla
        [ForeignKey("UsuarioId")] public Usuarios? _usuario { get; set; }

    }
}
