using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.interfaces;
using presentacion_libreria.implementaciones;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class GastosModel : PageModel
    {
        private IGastosNegocio? iGastosNegocio;
        [BindProperty] public List<Gastos>? ListaGastos { get; set; }
        [BindProperty] public Gastos? Gasto { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public GastosModel()
        {
            iGastosNegocio = new GastosNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iGastosNegocio == null)
                    return;
                ListaGastos = iGastosNegocio.Consultar();
                Gasto = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Gasto = new Gastos()
            {
                FechaGasto = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Gasto = ListaGastos!.FirstOrDefault(x => x.Id == data);
                ListaGastos = null;
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
                if (Gasto == null)
                    return;
                if (Gasto.Id == 0)
                    Gasto = iGastosNegocio!.Guardar(Gasto!);
                else
                    Gasto = iGastosNegocio!.Modificar(Gasto!);
                if (Gasto.Id == 0)
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
                if (Gasto == null)
                    return;
                Gasto = iGastosNegocio!.Borrar(Gasto!);
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
                Gasto = ListaGastos!.FirstOrDefault(x => x.Id == data);
                ListaGastos = null;
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
