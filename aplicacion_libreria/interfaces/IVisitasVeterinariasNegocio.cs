

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IVisitasVeterinariasNegocio
    {
        List<VisitasVeterinarias> Consultar();
        VisitasVeterinarias Guardar(VisitasVeterinarias entidad);

        VisitasVeterinarias Modificar(VisitasVeterinarias entidad);
        void Borrar(VisitasVeterinarias entidad);
    }
}
