
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicacion_libreria.entidades
{
    public class Potreros
    {
        public int Id { get; set; }
        public int IdLugarAnimal { get; set; }
        [ForeignKey("IdLugarAnimal")] public LugarAnimales? _lugarAnimal { get; set; }
    }
}
