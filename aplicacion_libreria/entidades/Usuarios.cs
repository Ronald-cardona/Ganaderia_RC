
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }  
        
        public string Correo { get; set; }
       
        public string Contraseña { get; set; }


        public int RolId { get; set; }
        [ForeignKey("RolId")] public Roles? _rol { get; set; }


        [NotMapped] public List<Roles>? Roles { get; set; }

        [NotMapped] public List<Animales>? Animales { get; set; }

        [NotMapped] public List<Personas>? Personas { get; set; }
        [NotMapped] public List<Fincas>? Fincas { get; set; }
        [NotMapped] public List<LugarAnimales>? LugarAnimales { get; set; }
        [NotMapped] public List<Lotes>? Lotes { get; set; }
        [NotMapped] public List<HistorialPesos>? HistorialPesos { get; set; }
        [NotMapped] public List<Vacunas>? Vacunas { get; set; }
        [NotMapped] public List<AplicacionVacunas>? AplicacionVacunas { get; set; }

        [NotMapped] public List<VisitasVeterinarias>? VisitasVeterinarias { get; set; }
        [NotMapped] public List<Alimentos>? Alimentos { get; set; }
        [NotMapped] public List<BrindarAlimentos>? BrindarAlimentos { get; set; }
        [NotMapped] public List<Suplementos>? Suplementos { get; set; }

        [NotMapped] public List<BrindarSuplementos>? BrindarSuplementos { get; set; }

        [NotMapped] public List<Clientes>? Clientes { get; set; }

        [NotMapped] public List<Proveedores>? Proveedores { get; set; }
        [NotMapped] public List<Compras>? Compras { get; set; }
        [NotMapped] public List<Ventas>? Ventas { get; set; }

        [NotMapped] public List<Ingresos>? Ingresos { get; set; }

        [NotMapped] public List<Gastos>? Gastos { get; set; }

        [NotMapped] public Configuraciones? _configuracion { get; set; }
    }
}
