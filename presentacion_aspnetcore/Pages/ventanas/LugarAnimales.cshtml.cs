using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class LugarAnimalesModel : PageModel
    {
        private ILugarAnimalesNegocio? iLugarAnimalesNegocio;
        [BindProperty] public List<LugarAnimales>? ListaLugarAnimales { get; set; }
        [BindProperty] public LugarAnimales? LugarAnimal { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public LugarAnimalesModel()
        {
            iLugarAnimalesNegocio = new LugarAnimalesNegocio();
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

            ListaLugarAnimales = new LugarAnimalesNegocio().Consultar(correo!);

            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iLugarAnimalesNegocio == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                ListaLugarAnimales = iLugarAnimalesNegocio.Consultar(correo!);
                LugarAnimal = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            LugarAnimal = new LugarAnimales()
            {
                FechaIngreso = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                LugarAnimal = ListaLugarAnimales!.FirstOrDefault(x => x.Id == data);
                ListaLugarAnimales = null;
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
                if (LugarAnimal == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");

                if (LugarAnimal.Id == 0)
                    LugarAnimal = iLugarAnimalesNegocio!.Guardar(LugarAnimal!,correo!);
                else
                    LugarAnimal = iLugarAnimalesNegocio!.Modificar(LugarAnimal!);
                if (LugarAnimal.Id == 0)
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
                if (LugarAnimal == null)
                    return;
                LugarAnimal = iLugarAnimalesNegocio!.Borrar(LugarAnimal!);
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
                LugarAnimal = ListaLugarAnimales!.FirstOrDefault(x => x.Id == data);
                ListaLugarAnimales = null;
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
