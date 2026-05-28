using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class UsuariosModel : PageModel
    {
        private IUsuariosNegocio? iUsuariosNegocio;
        [BindProperty] public List<Usuarios>? ListaUsuarios { get; set; }
        [BindProperty] public Usuarios? Usuario { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public UsuariosModel()
        {
            iUsuariosNegocio = new UsuariosNegocio();
        }


      



        public void OnGet()
        {
           

            
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iUsuariosNegocio == null)
                    return;
                ListaUsuarios = iUsuariosNegocio.Consultar();
                Usuario = null;
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
                Usuario = ListaUsuarios!.FirstOrDefault(x => x.Id == data);
                ListaUsuarios = null;
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
                if (Usuario == null)
                    return ;

               



                if (Usuario.Id == 0)
                    Usuario = iUsuariosNegocio!.Guardar(Usuario!);
                else
                    Usuario = iUsuariosNegocio!.Modificar(Usuario!);

              

                if (Usuario.Id == 0)
                    return ;
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
                if (Usuario == null)
                    return;
                Usuario = iUsuariosNegocio!.Borrar(Usuario!);
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
                Usuario = ListaUsuarios!.FirstOrDefault(x => x.Id == data);
                ListaUsuarios = null;
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
