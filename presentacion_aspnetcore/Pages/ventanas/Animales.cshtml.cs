using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class AnimalesModel : PageModel
    {
        private IAnimalesNegocio? iAnimalesNegocio;
        [BindProperty] public List<Animales>? ListaAnimales { get; set; }
        
        [BindProperty] public Animales? Animal { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public AnimalesModel()
        {
            iAnimalesNegocio = new AnimalesNegocio();
        }

        

        public void OnGet()
        {
            Animal = new Animales();
            OnPostBtRefrescar();
            


        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iAnimalesNegocio == null)
                    return;
                ListaAnimales = iAnimalesNegocio.Consultar();
                Animal = null;
                
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        //public void OnPostBtNuevo()
        //{
        //    Animal = new Animales()
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
                
                Animal = ListaAnimales!.FirstOrDefault(x => x.Id == data);
                ListaAnimales = null;
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
                if (Animal == null)
                    return;
                if (Animal.Id == 0)
                    Animal = iAnimalesNegocio!.Guardar(Animal!);
                else
                    Animal = iAnimalesNegocio!.Modificar(Animal!);
                if (Animal.Id == 0)
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
                if (Animal == null)
                    return;
                Animal = iAnimalesNegocio!.Borrar(Animal!);
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
                Animal = ListaAnimales!.FirstOrDefault(x => x.Id == data);
                ListaAnimales = null;
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


        public IActionResult OnPostReportePdf(int Id)

        {
            var negocio = new aplicacion_libreria.implementaciones.AnimalesNegocio();


            byte[] pdf = negocio.GenerarReporte(Id);


            return File(pdf, "application/pdf", "ReporteAnimales.pdf");

        }
    }
}
