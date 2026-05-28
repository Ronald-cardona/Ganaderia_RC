using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using presentacion_libreria.implementaciones;

namespace presentacion_aspnetcore.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Correo { get; set; }
        [BindProperty] public string? Contraseña { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Correo = string.Empty;
                Contraseña = string.Empty;
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
            }
        }

        public IActionResult OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Correo) ||
                    string.IsNullOrEmpty(Contraseña))
                {
                    ViewData["Error"] =
                        "Ingrese usuario y contraseña";

                    return Page();
                }

                var negocio = new aplicacion_libreria.implementaciones.UsuariosNegocio();


                var usuario =
                    negocio.Login(
                        Correo!,
                        Contraseña!);

                if (usuario == null)
                {
                    ViewData["Error"] =
                        "Usuario o contraseña incorrectos";

                    return Page();
                }

                HttpContext.Session.SetString(
                    "Usuario",
                    usuario.Correo!);

                // guardar sesión rol
                HttpContext.Session.SetString("Rol", usuario._rol!.Tipo!);

                EstaLogueado = true;
                // REDIRECCIONAR AL SISTEMA
                return RedirectToPage("/ventanas/Fincas");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return Page();
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
            }
        }
    }
}
