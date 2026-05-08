

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Gastos
    {
        public int Id { get; set; }  
        public DateTime FechaGasto { get; set; }
        public decimal CostoGasto { get; set; }
        public string? DescripcionGasto { get; set; }

        public int CompraId { get; set; }
        public int AlimentoId { get; set; }
        public int VacunaId { get; set; }
        public int SuplementoId { get; set; }
        public int PersonaId { get; set; }

        [ForeignKey("CompraId")] public Compras? _compra { get; set; }
        [ForeignKey("AlimentoId")] public Alimentos? _alimento { get; set; }
        [ForeignKey("VacunaId")] public Vacunas? _vacuna { get; set; }
        [ForeignKey("SuplementoId")] public Suplementos? _suplemento { get; set; }
        [ForeignKey("PersonaId")] public Personas? _persona { get; set; }


    } //calcular el gato total 
}
