

using aplicacion_libreria.entidades;

namespace presentacion_libreria.interfaces
{
    public interface IVisitasVeterinariasNegocio
    {
        List<VisitasVeterinarias> Consultar();
        VisitasVeterinarias Guardar(VisitasVeterinarias entidad);
        VisitasVeterinarias Modificar(VisitasVeterinarias entidad);
        VisitasVeterinarias Borrar(VisitasVeterinarias entidad);
    }
}
