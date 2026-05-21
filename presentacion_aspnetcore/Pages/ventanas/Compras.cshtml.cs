using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class ComprasModel : PageModel
    {
        private IComprasNegocio? iComprasNegocio;
        [BindProperty] public List<Compras>? ListaCompras { get; set; }
        [BindProperty] public Compras? Compra { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public ComprasModel()
        {
            iComprasNegocio = new ComprasNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iComprasNegocio == null)
                    return;
                ListaCompras = iComprasNegocio.Consultar();
                Compra = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Compra = new Compras()
            {
                FechaCompra = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Compra = ListaCompras!.FirstOrDefault(x => x.Id == data);
                ListaCompras = null;
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
                if (Compra == null)
                    return;
                if (Compra.Id == 0)
                    Compra = iComprasNegocio!.Guardar(Compra!);
                else
                    Compra = iComprasNegocio!.Modificar(Compra!);
                if (Compra.Id == 0)
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
                if (Compra == null)
                    return;
                Compra = iComprasNegocio!.Borrar(Compra!);
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
                Compra = ListaCompras!.FirstOrDefault(x => x.Id == data);
                ListaCompras = null;
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
