using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class LotesModel : PageModel
    {
        private ILotesNegocio? iLotesNegocio;
        [BindProperty] public List<Lotes>? ListaLotes { get; set; }
        [BindProperty] public Lotes? Lote { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public LotesModel()
        {
            iLotesNegocio = new LotesNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
            
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iLotesNegocio == null)
                    return;
                ListaLotes = iLotesNegocio.Consultar();
                Lote = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Lote = new Lotes()
            {
                FechaCreacion = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Lote = ListaLotes!.FirstOrDefault(x => x.Id == data);
                ListaLotes = null;
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
                if (Lote == null)
                    return;
                if (Lote.Id == 0)
                    Lote = iLotesNegocio!.Guardar(Lote!);
                else
                    Lote = iLotesNegocio!.Modificar(Lote!);
                if (Lote.Id == 0)
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
                if (Lote == null)
                    return;
                Lote = iLotesNegocio!.Borrar(Lote!);
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
                Lote = ListaLotes!.FirstOrDefault(x => x.Id == data);
                ListaLotes = null;
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
