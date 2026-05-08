

namespace aplicacion_libreria.entidades
{
    public class Estados
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Animales? _animal { get; set; }
    }
}
