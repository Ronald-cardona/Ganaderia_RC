using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class ClientesModel : PageModel
    {
        private IClientesNegocio? iClientesNegocio;
        [BindProperty] public List<Clientes>? ListaClientes { get; set; }
        [BindProperty] public Clientes? Cliente { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public ClientesModel()
        {
            iClientesNegocio = new ClientesNegocio();
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

            ListaClientes = new ClientesNegocio().Consultar(correo!);

            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iClientesNegocio == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                ListaClientes = iClientesNegocio.Consultar(correo!);
                Cliente = null;
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
                Cliente = ListaClientes!.FirstOrDefault(x => x.Id == data);
                ListaClientes = null;
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
                if (Cliente == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                if (Cliente.Id == 0)
                    Cliente = iClientesNegocio!.Guardar(Cliente!,correo!);
                else
                    Cliente = iClientesNegocio!.Modificar(Cliente!);
                if (Cliente.Id == 0)
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
                if (Cliente == null)
                    return;
                Cliente = iClientesNegocio!.Borrar(Cliente!);
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
                Cliente = ListaClientes!.FirstOrDefault(x => x.Id == data);
                ListaClientes = null;
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
