

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? string_conexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.string_conexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Alimentos>? Alimentos { get; set; }
        public DbSet<Animales>? Animales { get; set; }
        public DbSet<AplicacionVacunas>? AplicacionVacunas { get; set; }
        public DbSet<BrindarAlimentos>? BrindarAlimentos { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<Configuraciones>? Configuraciones { get; set; }
        public DbSet<Corrales>? Corrales { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Estados>? Estados { get; set; }
        public DbSet<Fincas>? Fincas { get; set; }
        public DbSet<Gastos>? Gastos { get; set; }
        public DbSet<HistorialPesos>? HistorialPesos { get; set; }
        public DbSet<Ingresos>? Ingresos { get; set; }
        public DbSet<Lotes>? Lotes { get; set; }
        public DbSet<LugarAnimales>? LugarAnimales { get; set; }
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<PersonasNaturalesC>? PersonasNaturalesC { get; set; }
        public DbSet<PersonasNaturalesP>? PersonasNaturalesP { get; set; }
        public DbSet<Potreros>? Potreros { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<SubastasC>? SubastasC { get; set; }
        public DbSet<SubastasP>? SubastasP { get; set; }
        public DbSet<Suplementos>? Suplementos { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Vacunas>? Vacunas { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<Veterinarios>? Veterinarios { get; set; }
        public DbSet<VisitasVeterinarias>? VisitasVeterinarias { get; set; }
        public DbSet<BrindarSuplementos>? BrindarSuplementos { get; set; }

    }
}
