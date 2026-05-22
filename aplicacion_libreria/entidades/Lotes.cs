

using System.ComponentModel.DataAnnotations.Schema;


namespace aplicacion_libreria.entidades
{
    public class Lotes
    {
        public int Id { get; set; }  
        public string Codigo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CantidadAnimales { get; set; }

        
        [NotMapped] public List<Animales>? animal { get; set; } // Cuarta regla

    }

    //aca se saca el peso promedio del lote 
}
