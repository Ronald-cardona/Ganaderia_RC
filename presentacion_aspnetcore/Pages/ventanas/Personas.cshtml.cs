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
            //codigo para proteger paginas  no se puede ingresar sin registrarse antes
            var usuario = HttpContext.Session.GetString("Usuario");


            if (string.IsNullOrEmpty(usuario))
            {
                Response.Redirect("/");
                return;
            }

            //para manejar las sesiones 
            var correo = HttpContext.Session.GetString("Usuario");

            ListaPersonas = new PersonasNegocio().Consultar(correo!);
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iPersonasNegocio == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                ListaPersonas = iPersonasNegocio.Consultar(correo!);
                Persona = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

      
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
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");

                if (Persona.Id == 0)
                    Persona = iPersonasNegocio!.Guardar(Persona!,correo!);
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
