
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Animales
    {

        public int Id { get; set; }  
        public string Codigo { get; set; } //marca que lleva el animal o que se le pone en la finca
        public decimal PesoInicial { get; set; }
        public decimal? Ganancia { get; set; }
        public decimal? PorcentajeGanancia { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public bool Sexo { get; set; }

        public int? LoteId { get; set; }
        public int? CompraId { get; set; }
        public int EstadoId { get; set; }
        public int? VentaId { get; set; }
        public int LugarAnimalId { get; set; }

        [ForeignKey("LoteId")] public Lotes? _lote { get; set; }
        [ForeignKey("CompraId")] public Compras? _compra { get; set; }
        [ForeignKey("EstadoId")] public Estados? _estado { get; set; }
        [ForeignKey("VentaId")] public Ventas? _venta { get; set; }
        [ForeignKey("LugarAnimalId")] public LugarAnimales? _lugarAnimal { get; set; }

        [NotMapped] public List<AplicacionVacunas>? aplicacionVAcunas { get; set; } 
        [NotMapped] public List<VisitasVeterinarias>? visitaVeterinaria { get; set; }
        [NotMapped] public List<BrindarAlimentos>? brindarAlimentos { get; set; }
        [NotMapped] public List<BrindarSuplementos>? brindarSuplementos { get; set; }
        [NotMapped] public List<HistorialPesos>? historialPesos { get; set; }

    } //CALCULAR LA GANANCIA DEL ANIMAL Y EL PORCENTAJE DE GANANCIA
}
