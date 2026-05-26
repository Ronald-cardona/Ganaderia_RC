using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class AlimentosModel : PageModel
    {
        private IAlimentosNegocio? iAlimentosNegocio;
        [BindProperty] public List<Alimentos>? ListaAlimentos { get; set; }
        [BindProperty] public Alimentos? Alimento { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public AlimentosModel()
        {
            iAlimentosNegocio = new AlimentosNegocio();
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

            ListaAlimentos = new AlimentosNegocio().Consultar(correo!);
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iAlimentosNegocio == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                ListaAlimentos = iAlimentosNegocio.Consultar(correo!);
                Alimento = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Alimento = new Alimentos()
            {
                FechaCompraAlimento = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Alimento = ListaAlimentos!.FirstOrDefault(x => x.Id == data);
                ListaAlimentos = null;
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
                if (Alimento == null)
                    return;
                //manejo de sesiones
                var correo = HttpContext.Session.GetString("Usuario");
                if (Alimento.Id == 0)
                    Alimento = iAlimentosNegocio!.Guardar(Alimento!,correo!);
                else
                    Alimento = iAlimentosNegocio!.Modificar(Alimento!);
                if (Alimento.Id == 0)
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
                if (Alimento == null)
                    return;
                Alimento = iAlimentosNegocio!.Borrar(Alimento!);
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
                Alimento = ListaAlimentos!.FirstOrDefault(x => x.Id == data);
                ListaAlimentos = null;
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
