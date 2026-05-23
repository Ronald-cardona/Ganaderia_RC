using aplicacion_libreria.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_libreria.implementaciones;
using presentacion_libreria.interfaces;

namespace presentacion_aspnetcore.Pages.ventanas
{
    public class RolesModel : PageModel
    {
        private IRolesNegocio? iRolesNegocio;
        [BindProperty] public List<Roles>? ListaRoles { get; set; }
        [BindProperty] public Roles? Rol { get; set; }
        [BindProperty] public bool Borrando { get; set; }


        public RolesModel()
        {
            iRolesNegocio = new RolesNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (iRolesNegocio == null)
                    return;
                ListaRoles = iRolesNegocio.Consultar();
                Rol = null;
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
                Rol = ListaRoles!.FirstOrDefault(x => x.Id == data);
                ListaRoles = null;
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
                if (Rol == null)
                    return;
                if (Rol.Id == 0)
                    Rol = iRolesNegocio!.Guardar(Rol!);
                else
                    Rol = iRolesNegocio!.Modificar(Rol!);
                if (Rol.Id == 0)
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
                if (Rol == null)
                    return;
                Rol = iRolesNegocio!.Borrar(Rol!);
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
                Rol = ListaRoles!.FirstOrDefault(x => x.Id == data);
                ListaRoles = null;
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
