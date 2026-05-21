using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class VacunasModel : PageModel
    {
        private IVacunasNegocio? iVacunasNegocio;
        [BindProperty] public List<Vacunas>? ListaVacunas { get; set; }
        [BindProperty] public Vacunas? Vacuna { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public VacunasModel()
        {
            iVacunasNegocio = new VacunasNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iVacunasNegocio == null)
                    return;
                ListaVacunas = iVacunasNegocio.Consultar();
                Vacuna = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        //public void OnPostBtNuevo()
        //{
        //    Vacuna = new Vacunas()
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
                Vacuna = ListaVacunas!.FirstOrDefault(x => x.Id == data);
                ListaVacunas = null;
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
                if (Vacuna == null)
                    return;
                if (Vacuna.Id == 0)
                    Vacuna = iVacunasNegocio!.Guardar(Vacuna!);
                else
                    Vacuna = iVacunasNegocio!.Modificar(Vacuna!);
                if (Vacuna.Id == 0)
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
                if (Vacuna == null)
                    return;
                Vacuna = iVacunasNegocio!.Borrar(Vacuna!);
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
                Vacuna = ListaVacunas!.FirstOrDefault(x => x.Id == data);
                ListaVacunas = null;
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
