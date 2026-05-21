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
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iIngresosNegocio == null)
                    return;
                ListaIngresos = iIngresosNegocio.Consultar();
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
                if (Ingreso.Id == 0)
                    Ingreso = iIngresosNegocio!.Guardar(Ingreso!);
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
