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
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iHistorialPesosNegocio == null)
                    return;
                ListaHistorialPesos = iHistorialPesosNegocio.Consultar();
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
                if (HistorialPeso.Id == 0)
                    HistorialPeso = iHistorialPesosNegocio!.Guardar(HistorialPeso!);
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
    }
}
