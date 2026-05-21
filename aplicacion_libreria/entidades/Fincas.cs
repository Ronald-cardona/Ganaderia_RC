

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Fincas
    {
        public int Id { get; set; }  
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direcccion { get; set; }
        public decimal ExtensionMetro { get; set; }

        [NotMapped] public List<Empleados>? _empleado { get; set; } 
        [NotMapped] public List<LugarAnimales>? _lugarAnimal { get; set; }
    }
    //se saca la extension en hectareas de la finca 
}
