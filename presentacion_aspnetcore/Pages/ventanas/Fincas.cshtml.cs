
using aplicacion_libreria.entidades;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class FincasModel : PageModel
    {
        private IFincasNegocio? iFincasNegocio;
        [BindProperty] public List<Fincas>? ListaFincas { get; set; }
        [BindProperty] public Fincas? Finca { get; set; }
        [BindProperty] public Climas? ClimaActual { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public FincasModel()
        {
            iFincasNegocio = new FincasNegocio();
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
            //var correo = HttpContext.Session.GetString("Usuario");
            OnPostBtRefrescar();

            // CARGAR FINCAS
            //ListaFincas =
            //    new 
            //    FincasNegocio()
            //    .Consultar(correo!);
           

            if (ListaFincas.Any())
            {
                var finca =
                    ListaFincas.First();

                if (finca.Latitud != null &&
                    finca.Longitud != null)
                {
                    ClimaActual = new aplicacion_libreria.implementaciones.ClimasNegocio().ConsultarClima(
                            finca.Latitud.Value,
                            finca.Longitud.Value);

                  
                }
            }

                   
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iFincasNegocio == null)
                    return;

                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");

                ListaFincas = iFincasNegocio.Consultar(correo!);
                Finca = null;
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
                Finca = ListaFincas!.FirstOrDefault(x => x.Id == data);
                ListaFincas = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public IActionResult OnPostBtGuardar()
        {
            try
            {
                if (Finca == null)
                    return Page();
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                if (Finca.Id == 0)
                    Finca = iFincasNegocio!.Guardar(Finca!,correo!);
                else
                    Finca = iFincasNegocio!.Modificar(Finca!);
                return RedirectToPage();

                if (Finca.Id == 0)
                    return Page();
                //OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return Page();
            }
        }

        public IActionResult OnPostBtBorrar()
        {
            try
            {
                if (Finca == null)
                    return Page();
                Finca = iFincasNegocio!.Borrar(Finca!);
                // OnPostBtRefrescar();
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return Page();
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Finca = ListaFincas!.FirstOrDefault(x => x.Id == data);
                ListaFincas = null;
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
