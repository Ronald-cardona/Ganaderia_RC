using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class ProveedoresModel : PageModel
    {
        private IProveedoresNegocio? iProveedoresNegocio;
        [BindProperty] public List<Proveedores>? ListaProveedores { get; set; }
        [BindProperty] public Proveedores? Proveedor { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public ProveedoresModel()
        {
            iProveedoresNegocio = new ProveedoresNegocio();
        }

        public void OnGet()
        {

            //codigo para proteger paginas  no se puede ingresar sin registrarse antes
            var usuario = HttpContext.Session.GetString("Usuario");


            if (string.IsNullOrEmpty(usuario))
            {
                Response.Redirect("/");
                return;
            }

            //para manejar las sesiones 
            var correo = HttpContext.Session.GetString("Usuario");

            ListaProveedores = new ProveedoresNegocio().Consultar(correo!);
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iProveedoresNegocio == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                ListaProveedores = iProveedoresNegocio.Consultar(correo!);
                Proveedor = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Proveedor = ListaProveedores!.FirstOrDefault(x => x.Id == data);
                ListaProveedores = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Proveedor == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                if (Proveedor.Id == 0)
                    Proveedor = iProveedoresNegocio!.Guardar(Proveedor!,correo!);
                else
                    Proveedor = iProveedoresNegocio!.Modificar(Proveedor!);
                if (Proveedor.Id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Proveedor == null)
                    return;
                Proveedor = iProveedoresNegocio!.Borrar(Proveedor!);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Proveedor = ListaProveedores!.FirstOrDefault(x => x.Id == data);
                ListaProveedores = null;
                Borrando = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}
