

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class LugarAnimales
    {
        public int Id { get; set; }  
        public string Codigo { get; set; }
        public decimal Metros { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }


        public int FincaId { get; set; } 
        [ForeignKey("FincaId")] public Fincas? _finca { get; set; }



        public List<Animales>? Animales { get; set; }
        public List<Potreros>? Potreros { get; set; }
        public List<Corrales>? Corrales { get; set; }


    }
}
