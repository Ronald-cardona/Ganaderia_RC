using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class FincasModel : PageModel
    {
        private IFincasNegocio? iFincasNegocio;
        [BindProperty] public List<Fincas>? ListaFincas { get; set; }
        [BindProperty] public Fincas? Finca { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public FincasModel()
        {
            iFincasNegocio = new FincasNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iFincasNegocio == null)
                    return;
                ListaFincas = iFincasNegocio.Consultar();
                Finca = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        //public void OnPostBtNuevo()
        //{
        //    Finca = new Fincas()
        //    {
        //        Fecha = DateTime.Now
        //    };
        //    Borrando = false;
        //}

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Finca = ListaFincas!.FirstOrDefault(x => x.Id == data);
                ListaFincas = null;
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
                if (Finca == null)
                    return;
                if (Finca.Id == 0)
                    Finca = iFincasNegocio!.Guardar(Finca!);
                else
                    Finca = iFincasNegocio!.Modificar(Finca!);
                if (Finca.Id == 0)
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
                if (Finca == null)
                    return;
                Finca = iFincasNegocio!.Borrar(Finca!);
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
                Finca = ListaFincas!.FirstOrDefault(x => x.Id == data);
                ListaFincas = null;
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
