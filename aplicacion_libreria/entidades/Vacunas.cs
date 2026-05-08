

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Vacunas
    {
        public int Id { get; set; }  
        public string Nombre { get; set; }
        public decimal CostoVacuna { get; set; }
        public string LoteVacuna { get; set; }
        public DateTime FechaCompraVacuna { get; set; }


        //Listas
        [NotMapped] public List<AplicacionVacunas>? aplicacionVAcunas { get; set; }
        [NotMapped] public List<Gastos>? gasto { get; set; }

    }
}
