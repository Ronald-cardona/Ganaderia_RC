using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class ConfiguracionesModel : PageModel
    {
        private IConfiguracionesNegocio? iConfiguracionesNegocio;
        [BindProperty] public List<Configuraciones>? ListaConfiguraciones { get; set; }
        [BindProperty] public Configuraciones? Configuracion { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public ConfiguracionesModel()
        {
            iConfiguracionesNegocio = new ConfiguracionesNegocio();
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

            ListaConfiguraciones = new ConfiguracionesNegocio().Consultar(correo!);
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iConfiguracionesNegocio == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                ListaConfiguraciones = iConfiguracionesNegocio.Consultar(correo!);
                Configuracion = null;
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
                Configuracion = ListaConfiguraciones!.FirstOrDefault(x => x.Id == data);
                ListaConfiguraciones = null;
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
                if (Configuracion == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                if (Configuracion.Id == 0)
                    Configuracion = iConfiguracionesNegocio!.Guardar(Configuracion!,correo!);
                else
                    Configuracion = iConfiguracionesNegocio!.Modificar(Configuracion!);
                if (Configuracion.Id == 0)
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
                if (Configuracion == null)
                    return;
                Configuracion = iConfiguracionesNegocio!.Borrar(Configuracion!);
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
                Configuracion = ListaConfiguraciones!.FirstOrDefault(x => x.Id == data);
                ListaConfiguraciones = null;
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
