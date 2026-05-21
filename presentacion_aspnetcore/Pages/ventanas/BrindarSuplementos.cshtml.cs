using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class BrindarSuplementosModel : PageModel
    {
        private IBrindarSuplementosNegocio? iBrindarSuplementosNegocio;
        [BindProperty] public List<BrindarSuplementos>? ListaBrindarSuplementos { get; set; }
        [BindProperty] public BrindarSuplementos? BrindarSuplemento { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public BrindarSuplementosModel()
        {
            iBrindarSuplementosNegocio = new BrindarSuplementosNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iBrindarSuplementosNegocio == null)
                    return;
                ListaBrindarSuplementos = iBrindarSuplementosNegocio.Consultar();
                BrindarSuplemento = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            BrindarSuplemento = new BrindarSuplementos()
            {
                FechaBrindarSuplemetos = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                BrindarSuplemento = ListaBrindarSuplementos!.FirstOrDefault(x => x.Id == data);
                ListaBrindarSuplementos = null;
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
                if (BrindarSuplemento == null)
                    return;
                if (BrindarSuplemento.Id == 0)
                    BrindarSuplemento = iBrindarSuplementosNegocio!.Guardar(BrindarSuplemento!);
                else
                    BrindarSuplemento = iBrindarSuplementosNegocio!.Modificar(BrindarSuplemento!);
                if (BrindarSuplemento.Id == 0)
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
                if (BrindarSuplemento == null)
                    return;
                BrindarSuplemento = iBrindarSuplementosNegocio!.Borrar(BrindarSuplemento!);
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
                BrindarSuplemento = ListaBrindarSuplementos!.FirstOrDefault(x => x.Id == data);
                ListaBrindarSuplementos = null;
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
