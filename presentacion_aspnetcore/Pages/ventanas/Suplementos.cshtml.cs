using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class SuplementosModel : PageModel
    {
        private ISuplementosNegocio? iSuplementosNegocio;
        [BindProperty] public List<Suplementos>? ListaSuplementos { get; set; }
        [BindProperty] public Suplementos? Suplemento { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public SuplementosModel()
        {
            iSuplementosNegocio = new SuplementosNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iSuplementosNegocio == null)
                    return;
                ListaSuplementos = iSuplementosNegocio.Consultar();
                Suplemento = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Suplemento = new Suplementos()
            {
                FechaCompraSuplemento = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Suplemento = ListaSuplementos!.FirstOrDefault(x => x.Id == data);
                ListaSuplementos = null;
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
                if (Suplemento == null)
                    return;
                if (Suplemento.Id == 0)
                    Suplemento = iSuplementosNegocio!.Guardar(Suplemento!);
                else
                    Suplemento = iSuplementosNegocio!.Modificar(Suplemento!);
                if (Suplemento.Id == 0)
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
                if (Suplemento == null)
                    return;
                Suplemento = iSuplementosNegocio!.Borrar(Suplemento!);
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
                Suplemento = ListaSuplementos!.FirstOrDefault(x => x.Id == data);
                ListaSuplementos = null;
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
