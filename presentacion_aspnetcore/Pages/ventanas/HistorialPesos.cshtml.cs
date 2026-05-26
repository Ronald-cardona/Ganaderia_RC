using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;



namespace presentacion_aspnetcore.Pages.ventanas
{
    public class HistorialPesosModel : PageModel
    {
        private IHistorialPesosNegocio? iHistorialPesosNegocio;
        [BindProperty] public List<HistorialPesos>? ListaHistorialPesos { get; set; }
        [BindProperty] public HistorialPesos? HistorialPeso { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public HistorialPesosModel()
        {
            iHistorialPesosNegocio = new HistorialPesosNegocio();
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

            ListaHistorialPesos = new HistorialPesosNegocio().Consultar(correo!);
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iHistorialPesosNegocio == null)
                    return;

                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                ListaHistorialPesos = iHistorialPesosNegocio.Consultar(correo!);
                HistorialPeso = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            HistorialPeso = new HistorialPesos()
            {
                FechaPesajeActual = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                HistorialPeso = ListaHistorialPesos!.FirstOrDefault(x => x.Id == data);
                ListaHistorialPesos = null;
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
                if (HistorialPeso == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                if (HistorialPeso.Id == 0)
                    HistorialPeso = iHistorialPesosNegocio!.Guardar(HistorialPeso!,correo!);
                else
                    HistorialPeso = iHistorialPesosNegocio!.Modificar(HistorialPeso!);
                if (HistorialPeso.Id == 0)
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
                if (HistorialPeso == null)
                    return;
                HistorialPeso = iHistorialPesosNegocio!.Borrar(HistorialPeso!);
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
                HistorialPeso = ListaHistorialPesos!.FirstOrDefault(x => x.Id == data);
                ListaHistorialPesos = null;
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


        public IActionResult OnPostReportePdf(int IdAnimal)
    
        {
            var negocio = new aplicacion_libreria.implementaciones.HistorialPesosNegocio();
            

            byte[] pdf = negocio.GenerarReporte(IdAnimal);
            

            return File(pdf, "application/pdf", "ReporteHistorialPesos.pdf");
           
        }



    }
}
