using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class VisitasVeterinariasModel : PageModel
    {
        private IVisitasVeterinariasNegocio? iVisitasVeterinariasNegocio;
        [BindProperty] public List<VisitasVeterinarias>? ListaVisitasVeterinarias { get; set; }
        [BindProperty] public VisitasVeterinarias? VisitasVeterinaria { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public VisitasVeterinariasModel()
        {
            iVisitasVeterinariasNegocio = new VisitasVeterinariasNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iVisitasVeterinariasNegocio == null)
                    return;
                ListaVisitasVeterinarias = iVisitasVeterinariasNegocio.Consultar();
                VisitasVeterinaria = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            VisitasVeterinaria = new VisitasVeterinarias()
            {
                FechaVisita = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                VisitasVeterinaria = ListaVisitasVeterinarias!.FirstOrDefault(x => x.Id == data);
                ListaVisitasVeterinarias = null;
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
                if (VisitasVeterinaria == null)
                    return;
                if (VisitasVeterinaria.Id == 0)
                    VisitasVeterinaria = iVisitasVeterinariasNegocio!.Guardar(VisitasVeterinaria!);
                else
                    VisitasVeterinaria = iVisitasVeterinariasNegocio!.Modificar(VisitasVeterinaria!);
                if (VisitasVeterinaria.Id == 0)
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
                if (VisitasVeterinaria == null)
                    return;
                VisitasVeterinaria = iVisitasVeterinariasNegocio!.Borrar(VisitasVeterinaria!);
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
                VisitasVeterinaria = ListaVisitasVeterinarias!.FirstOrDefault(x => x.Id == data);
                ListaVisitasVeterinarias = null;
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
