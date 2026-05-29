using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class RegistrosModel : PageModel
    {
        private IUsuariosNegocio?
        iUsuariosNegocio;

        [BindProperty]
        public Usuarios?
            Usuario
        { get; set; }

        public void OnGet()
        {
            Usuario = new Usuarios();
           
        }

        public IActionResult OnPostBtGuardar()
        {
            try
            {
                if (Usuario == null)
                    return Page();

                var rolCliente = new RolesNegocio().Consultar().FirstOrDefault(x => x.Tipo.Trim().ToLower() == "cliente");
               

                if (rolCliente == null)
                    throw new Exception("No existe el rol cliente");
                

                Usuario.RolId = rolCliente.Id;
              

                iUsuariosNegocio = new UsuariosNegocio();
              

                Usuario = iUsuariosNegocio.Guardar(Usuario);
               

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
               

                return Page();
            }
        }
    }
}
