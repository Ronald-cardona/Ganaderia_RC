using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class BrindarAlimentosModel : PageModel
    {
        private IBrindarAlimentosNegocio? iBrindarAlimentosNegocio;
        [BindProperty] public List<BrindarAlimentos>? ListaBrindarAlimentos { get; set; }
        [BindProperty] public BrindarAlimentos? BrindarAlimento { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public BrindarAlimentosModel()
        {
            iBrindarAlimentosNegocio = new BrindarAlimentosNegocio();
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

            ListaBrindarAlimentos = new BrindarAlimentosNegocio().Consultar(correo!);
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iBrindarAlimentosNegocio == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");

                ListaBrindarAlimentos = iBrindarAlimentosNegocio.Consultar(correo!);
                BrindarAlimento = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            BrindarAlimento = new BrindarAlimentos()
            {
                FechaBrindarAlimentos = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                BrindarAlimento = ListaBrindarAlimentos!.FirstOrDefault(x => x.Id == data);
                ListaBrindarAlimentos = null;
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
                if (BrindarAlimento == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                if (BrindarAlimento.Id == 0)
                    BrindarAlimento = iBrindarAlimentosNegocio!.Guardar(BrindarAlimento!,correo!);
                else
                    BrindarAlimento = iBrindarAlimentosNegocio!.Modificar(BrindarAlimento!);
                if (BrindarAlimento.Id == 0)
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
                if (BrindarAlimento == null)
                    return;
                BrindarAlimento = iBrindarAlimentosNegocio!.Borrar(BrindarAlimento!);
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
                BrindarAlimento = ListaBrindarAlimentos!.FirstOrDefault(x => x.Id == data);
                ListaBrindarAlimentos = null;
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
