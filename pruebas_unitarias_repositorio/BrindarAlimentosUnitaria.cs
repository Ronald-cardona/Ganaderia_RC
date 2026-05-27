using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias_repositorio;

[TestClass]
public class BrindarAlimentosUnitaria
{
    private IConexion? iConexion;
    private BrindarAlimentos? entidad;

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
        var lista = iConexion.BrindarAlimentos!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

        this.entidad = new BrindarAlimentos()
        {
            FechaBrindarAlimentos = DateTime.Now,

            UsuarioId = 5,
            IdAnimal = 10,

            AlimentoId = 1,



        };
        this.iConexion.BrindarAlimentos!.Add(this.entidad!);
        this.iConexion.SaveChanges();

        if (this.entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

        this.entidad!.FechaBrindarAlimentos = DateTime.Now;

        var entry = this.iConexion!.Entry<BrindarAlimentos>(this.entidad!);
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

        this.iConexion.BrindarAlimentos!.Remove(this.entidad!);
        this.iConexion.SaveChanges();
    }
}
