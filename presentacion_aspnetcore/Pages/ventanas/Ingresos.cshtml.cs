using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class IngresosModel : PageModel
    {
        private IIngresosNegocio? iIngresosNegocio;
        [BindProperty] public List<Ingresos>? ListaIngresos { get; set; }
        [BindProperty] public Ingresos? Ingreso { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public IngresosModel()
        {
            iIngresosNegocio = new IngresosNegocio();
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

            ListaIngresos = new IngresosNegocio().Consultar(correo!);
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iIngresosNegocio == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                ListaIngresos = iIngresosNegocio.Consultar(correo!);
                Ingreso = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Ingreso = new Ingresos()
            {
                FechaIngreso = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Ingreso = ListaIngresos!.FirstOrDefault(x => x.Id == data);
                ListaIngresos = null;
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
                if (Ingreso == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                if (Ingreso.Id == 0)
                    Ingreso = iIngresosNegocio!.Guardar(Ingreso!,correo!);
                else
                    Ingreso = iIngresosNegocio!.Modificar(Ingreso!);
                if (Ingreso.Id == 0)
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
                if (Ingreso == null)
                    return;
                Ingreso = iIngresosNegocio!.Borrar(Ingreso!);
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
                Ingreso = ListaIngresos!.FirstOrDefault(x => x.Id == data);
                ListaIngresos = null;
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
