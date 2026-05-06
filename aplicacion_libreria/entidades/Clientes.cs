

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Clientes
    {
        public int Id { get; set; }  
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }


        [NotMapped] public List<Ventas>? ventas { get; set; } 
    }
}
