using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class PersonasModel : PageModel
    {
        private IPersonasNegocio? iPersonasNegocio;
        [BindProperty] public List<Personas>? ListaPersonas { get; set; }
        [BindProperty] public Personas? Persona { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public PersonasModel()
        {
            iPersonasNegocio = new PersonasNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iPersonasNegocio == null)
                    return;
                ListaPersonas = iPersonasNegocio.Consultar();
                Persona = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        //public void OnPostBtNuevo()
        //{
        //    Persona = new Personas()
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
                Persona = ListaPersonas!.FirstOrDefault(x => x.Id == data);
                ListaPersonas = null;
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
                if (Persona == null)
                    return;
                if (Persona.Id == 0)
                    Persona = iPersonasNegocio!.Guardar(Persona!);
                else
                    Persona = iPersonasNegocio!.Modificar(Persona!);
                if (Persona.Id == 0)
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
                if (Persona == null)
                    return;
                Persona = iPersonasNegocio!.Borrar(Persona!);
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
                Persona = ListaPersonas!.FirstOrDefault(x => x.Id == data);
                ListaPersonas = null;
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
