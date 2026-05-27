using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias_repositorio;

[TestClass]
public class ConfiguracionesUnitaria
{
    private IConexion? iConexion;
    private Configuraciones? entidad;

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
        var lista = iConexion.Configuraciones!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

        this.entidad = new Configuraciones()
        {
            Idioma = "español" ,
            Moneda = "cop",
            Tema = true,
            UsuarioId = 2

        };
        this.iConexion.Configuraciones!.Add(this.entidad!);
        this.iConexion.SaveChanges();

        if (this.entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

        this.entidad!.Tema = false;

        var entry = this.iConexion!.Entry<Configuraciones>(this.entidad!);
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

        this.iConexion.Configuraciones!.Remove(this.entidad!);
        this.iConexion.SaveChanges();
    }
}
