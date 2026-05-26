

using aplicacion_libreria.entidades;

namespace aplicacion_libreria.interfaces
{
    public interface IVisitasVeterinariasNegocio
    {
        List<VisitasVeterinarias> Consultar(string correo);
        VisitasVeterinarias Guardar(VisitasVeterinarias entidad, string correo);

        VisitasVeterinarias Modificar(VisitasVeterinarias entidad);
        void Borrar(VisitasVeterinarias entidad);
    }
}
