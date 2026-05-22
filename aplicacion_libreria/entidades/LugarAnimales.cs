

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace aplicacion_libreria.entidades
{
    public class LugarAnimales
    {
        public int Id { get; set; }  
        public string Codigo { get; set; }
        public decimal Metros { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }


        public int FincaId { get; set; } 
        [ForeignKey("FincaId")] public Fincas? _finca { get; set; }


        
        [NotMapped] public List<Animales>? Animales { get; set; }
        [NotMapped] public List<Potreros>? Potreros { get; set; }
        [NotMapped] public List<Corrales>? Corrales { get; set; }


    }
}
