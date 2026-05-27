using Microsoft.VisualStudio.TestTools.UnitTesting;


using aplicacion_libreria.entidades;

using presentacion_libreria.implementaciones;

namespace Pruebas_unitarias_Comunicaciones;

[TestClass]

public class RolesUnitaria
{
    private RolesNegocio? iRolesNegocio;
    private Roles? entidad;

    [TestMethod]
    public void Ejecutar()
    {
        Guardar();
        Consultar();
        Modificar();
        //Borrar();
    }

    private void Consultar()
    {
        this.iRolesNegocio =
            new RolesNegocio();

        var lista =
            this.iRolesNegocio
            .Consultar();

        if (lista.Count > 0)
            this.entidad = lista[0];
        return;

        throw new Exception("");
    }

    private void Guardar()
    {
        this.iRolesNegocio =
            new RolesNegocio();

        this.entidad =
            new Roles()
            {
                Tipo = "Administrador",
                
            };

        this.entidad = this.iRolesNegocio.Guardar(this.entidad);
       

       

        if (this.entidad.Id != 0)
            return;

        throw new Exception("");
    }

    private void Modificar()
    {
        this.iRolesNegocio =
            new RolesNegocio();

        this.entidad!.Tipo =
            "Cliente Modificado";

        this.entidad =
            this.iRolesNegocio
            .Modificar(this.entidad);

        if (this.entidad.Tipo ==
            "Cliente Modificado")
            return;

        throw new Exception("");
    }

    private void Borrar()
    {
        this.iRolesNegocio =
            new RolesNegocio();

        this.entidad =
            this.iRolesNegocio
            .Borrar(this.entidad!);

        if (this.entidad.Id == 0)
            return;

        throw new Exception("");
    }
}

