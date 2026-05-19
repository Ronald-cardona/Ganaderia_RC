
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int IdFinca { get; set; }

        [ForeignKey("IdPersona")] public Personas? _persona { get; set; }
        [ForeignKey("IdFinca")] public Fincas? _finca { get; set; }
    }
}
