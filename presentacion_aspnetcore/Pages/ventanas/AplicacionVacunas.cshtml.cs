using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class AplicacionVacunasModel : PageModel
    {
        private IAplicacionVacunasNegocio? iAplicacionVacunasNegocio;
        [BindProperty] public List<AplicacionVacunas>? ListaAplicacionVacunas { get; set; }
        [BindProperty] public AplicacionVacunas? AplicacionVacuna { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public AplicacionVacunasModel()
        {
            iAplicacionVacunasNegocio = new AplicacionVacunasNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iAplicacionVacunasNegocio == null)
                    return;
                ListaAplicacionVacunas = iAplicacionVacunasNegocio.Consultar();
                AplicacionVacuna = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            AplicacionVacuna = new AplicacionVacunas()
            {
                FechaAplicacion = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                AplicacionVacuna = ListaAplicacionVacunas!.FirstOrDefault(x => x.Id == data);
                ListaAplicacionVacunas = null;
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
                if (AplicacionVacuna == null)
                    return;
                if (AplicacionVacuna.Id == 0)
                    AplicacionVacuna = iAplicacionVacunasNegocio!.Guardar(AplicacionVacuna!);
                else
                    AplicacionVacuna = iAplicacionVacunasNegocio!.Modificar(AplicacionVacuna!);
                if (AplicacionVacuna.Id == 0)
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
                if (AplicacionVacuna == null)
                    return;
                AplicacionVacuna = iAplicacionVacunasNegocio!.Borrar(AplicacionVacuna!);
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
                AplicacionVacuna = ListaAplicacionVacunas!.FirstOrDefault(x => x.Id == data);
                ListaAplicacionVacunas = null;
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
