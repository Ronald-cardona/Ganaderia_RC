

using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class AlimentosNegocio : IAlimentosNegocio
    {
        private IConexion? iConexion;

        public List<Alimentos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            return this.iConexion.Alimentos!.ToList();
        }

        public Alimentos Guardar(Alimentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Alimentos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Alimentos Modificar(Alimentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Alimentos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Alimentos entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var alimento = this.iConexion.Alimentos.FirstOrDefault(e => e.Id == entidad.Id);

            if (alimento == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Alimentos.Remove(alimento);
            this.iConexion.SaveChanges();
        }
    }
}
