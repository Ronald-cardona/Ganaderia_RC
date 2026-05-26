

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IVisitasVeterinariasNegocio
    {
        List<VisitasVeterinarias> Consultar(string correo);
        VisitasVeterinarias Guardar(VisitasVeterinarias entidad, string correo);
        VisitasVeterinarias Modificar(VisitasVeterinarias entidad);
        VisitasVeterinarias Borrar(VisitasVeterinarias entidad);
    }
}
