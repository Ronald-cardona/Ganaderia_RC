

using aplicacion_libreria.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace aplicacion_libreria.interfaces
{
    public interface IConexion
    {
        string? string_conexion { get; set; }

         DbSet<Alimentos>? Alimentos { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }
        DbSet<Animales>? Animales { get; set; }
         DbSet<AplicacionVacunas>? AplicacionVacunas { get; set; }
         DbSet<BrindarAlimentos>? BrindarAlimentos { get; set; }
         DbSet<Clientes>? Clientes { get; set; }
         DbSet<Compras>? Compras { get; set; }
         DbSet<Configuraciones>? Configuraciones { get; set; }
         DbSet<Corrales>? Corrales { get; set; }
         DbSet<Empleados>? Empleados { get; set; }
         DbSet<Estados>? Estados { get; set; }
         DbSet<Fincas>? Fincas { get; set; }
         DbSet<Gastos>? Gastos { get; set; }
         DbSet<HistorialPesos>? HistorialPesos { get; set; }
         DbSet<Ingresos>? Ingresos { get; set; }
         DbSet<Lotes>? Lotes { get; set; }
         DbSet<LugarAnimales>? LugarAnimales { get; set; }
         DbSet<Personas>? Personas { get; set; }
         DbSet<PersonasNaturalesC>? PersonasNaturalesC { get; set; }
         DbSet<PersonasNaturalesP>? PersonasNaturalesP { get; set; }
         DbSet<Potreros>? Potreros { get; set; }
         DbSet<Proveedores>? Proveedores { get; set; }
         DbSet<Roles>? Roles { get; set; }
         DbSet<SubastasC>? SubastasC { get; set; }
         DbSet<SubastasP>? SubastasP { get; set; }
         DbSet<Suplementos>? Suplementos { get; set; }
         DbSet<Usuarios>? Usuarios { get; set; }
         DbSet<Vacunas>? Vacunas { get; set; }
         DbSet<Ventas>? Ventas { get; set; }
         DbSet<Veterinarios>? Veterinarios { get; set; }
         DbSet<VisitasVeterinarias>? VisitasVeterinarias { get; set; }
         DbSet<BrindarSuplementos>? BrindarSuplementos { get; set; }
         EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
