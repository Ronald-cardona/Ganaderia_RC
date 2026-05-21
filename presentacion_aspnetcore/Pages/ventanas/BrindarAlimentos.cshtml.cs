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
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iBrindarAlimentosNegocio == null)
                    return;
                ListaBrindarAlimentos = iBrindarAlimentosNegocio.Consultar();
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
                if (BrindarAlimento.Id == 0)
                    BrindarAlimento = iBrindarAlimentosNegocio!.Guardar(BrindarAlimento!);
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
