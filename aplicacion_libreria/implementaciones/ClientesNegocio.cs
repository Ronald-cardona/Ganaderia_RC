
using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class ClientesNegocio : IClientesNegocio
    {
        private IConexion? iConexion;

        public List<Clientes> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Clientes";
            this.iConexion.Auditorias!.Add(auditorias);
            this.iConexion.SaveChanges();


            return this.iConexion.Clientes!.ToList();
        }

        public Clientes Guardar(Clientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 





            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            this.iConexion.Clientes!.Add(entidad!);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó un nuevo Cliente";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Clientes Modificar(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó un  Cliente";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion!.SaveChanges();


            return entidad;


        }

        public void Borrar(Clientes entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var cliente = this.iConexion.Clientes.FirstOrDefault(e => e.Id == entidad.Id);

            if (cliente == null)
                throw new Exception("No existe el registro en la base de datos ");

            this.iConexion.Clientes.Remove(cliente);

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un Cliente";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();
        }
    }
}