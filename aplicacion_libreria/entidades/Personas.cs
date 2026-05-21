
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Personas
    {
        public int Id { get; set; }  // segunda regla
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }   
        public decimal Sueldo { get; set; }
        public bool Activo { get; set; }

        [NotMapped] public List<Gastos>? Gastos { get; set; }
        [NotMapped] public List<Empleados>? Empleados { get; set; }
        [NotMapped] public List<Veterinarios>? Veterinarios { get; set; }
    }
}
