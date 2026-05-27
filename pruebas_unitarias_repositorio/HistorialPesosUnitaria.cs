using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias_repositorio;

[TestClass]
public class HistorialPesosUnitaria
{
    private IConexion? iConexion;
    private HistorialPesos? entidad;

    [TestMethod]
    public void Ejecutar()
    {
        Guardar();
        Consultar();
        Modificar();
        Borrar();
    }

    private void Consultar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");
        var lista = iConexion.HistorialPesos!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

        this.entidad = new HistorialPesos()
        {
            FechaUltimoPesaje = DateTime.Now,
            FechaPesajeActual = DateTime.Now,
            PesoActual = 250,
            UltimoPeso = 10000,
            GananciaPeso = 5,
            GananciaDiaria = 1,
            DiasTranscurridos = 1,
            IdAnimal = 10,
            UsuarioId = 5,
           


        };
        this.iConexion.HistorialPesos!.Add(this.entidad!);
        this.iConexion.SaveChanges();

        if (this.entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

        this.entidad!.GananciaPeso = 500;

        var entry = this.iConexion!.Entry<HistorialPesos>(this.entidad!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

        this.iConexion.HistorialPesos!.Remove(this.entidad!);
        this.iConexion.SaveChanges();
    }
}
