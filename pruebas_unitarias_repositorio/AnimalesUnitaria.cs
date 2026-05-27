using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias_repositorio;

[TestClass]
public class AnimalesUnitaria
{
    private IConexion? iConexion;
    private Animales? entidad;

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
        var lista = iConexion.Animales!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

        this.entidad = new Animales()
        {
            Codigo = "test",
            PesoInicial = 200,
            Ganancia = 250,
            PorcentajeGanancia = 10000,
            Raza = "test",
            Edad = 1,
            Sexo = true,
            LoteId = 1,
            CompraId = 1,
            EstadoId = 1,
            VentaId = 1,
            LugarAnimalId = 1,
            UsuarioId = 5,


        };
        this.iConexion.Animales!.Add(this.entidad!);
        this.iConexion.SaveChanges();

        if (this.entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

        this.entidad!.Sexo = false;

        var entry = this.iConexion!.Entry<Animales>(this.entidad!);
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

        this.iConexion.Animales!.Remove(this.entidad!);
        this.iConexion.SaveChanges();
    }
}
