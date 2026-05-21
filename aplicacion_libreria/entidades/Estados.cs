

using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Estados
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        [NotMapped] public List<Animales>? animales { get; set; }
    }
}
