using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class VentasModel : PageModel
    {
        private IVentasNegocio? iVentasNegocio;
        [BindProperty] public List<Ventas>? ListaVentas { get; set; }
        [BindProperty] public Ventas? Venta { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public VentasModel()
        {
            iVentasNegocio = new VentasNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iVentasNegocio == null)
                    return;
                ListaVentas = iVentasNegocio.Consultar();
                Venta = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Venta = new Ventas()
            {
                FechaVenta = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Venta = ListaVentas!.FirstOrDefault(x => x.Id == data);
                ListaVentas = null;
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
                if (Venta == null)
                    return;
                if (Venta.Id == 0)
                    Venta = iVentasNegocio!.Guardar(Venta!);
                else
                    Venta = iVentasNegocio!.Modificar(Venta!);
                if (Venta.Id == 0)
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
                if (Venta == null)
                    return;
                Venta = iVentasNegocio!.Borrar(Venta!);
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
                Venta = ListaVentas!.FirstOrDefault(x => x.Id == data);
                ListaVentas = null;
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
