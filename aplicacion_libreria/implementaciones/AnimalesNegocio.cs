
using aplicacion_libreria.entidades;
using aplicacion_libreria.interfaces;
using aplicacion_libreria.nucleo;
using aplicacion_libreria.reportes;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_libreria.implementaciones
{
    public class AnimalesNegocio : IAnimalesNegocio
    {
        private IConexion? iConexion;

        public List<Animales> Consultar(string correo)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            Auditorias auditorias = new Auditorias();
            auditorias.Metodo = "Consultar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se consultó la lista de Animales";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();

            return this.iConexion.Animales!
            .Where(x => x._usuario!.Correo == correo) //filtrar por correo para que solo el usuario vea sus animales 
            .Include(x => x._lote)
            .Include(x => x._compra)
            .Include(x => x._estado)
            .Include(x => x._lugarAnimal)
            .ToList();

        }

        public Animales Guardar(Animales entidad, string correo)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //aca se hacen los calculos y los metodos del negocio 

           

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para que pueda guardar por usuario
            var usuario = this.iConexion.Usuarios!.First(x => x.Correo == correo);
            entidad.UsuarioId = usuario.Id;

            this.iConexion.Animales!.Add(entidad!);

            Auditorias auditorias = new Auditorias();

            auditorias.Metodo = "Guardar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se Guardó un nuevo Animal";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();

            //metodo que me cuenta la  cantidad de animales en un lote 
            var lote = this.iConexion.Lotes!.FirstOrDefault(x => x.Id == entidad.LoteId);
            if (lote != null)
            {
                lote.CantidadAnimales = this.iConexion.Animales!.Count(x => x.LoteId == lote.Id);
                this.iConexion.Lotes!.Update(lote);
                this.iConexion.SaveChanges();
            }
            return entidad;
        }

        public Animales Modificar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es obligatorio");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            //para saber cual animal modificar respecto al usuario 
            var animalBd = this.iConexion.Animales!.First(x => x.Id == entidad.Id);
            entidad.UsuarioId = animalBd.UsuarioId;

            var animalAnterior = this.iConexion.Animales
            .FirstOrDefault(x => x.Id == entidad.Id); // parte de  calculo de contar lote animales
            int? loteAnteriorId = animalAnterior.LoteId;

            var entry = this.iConexion!.Entry<Animales>(entidad);
            entry.State = EntityState.Modified;

            Auditorias auditorias = new Auditorias();

            auditorias.Metodo = "Modificar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se modificó un  animal";
            this.iConexion.Auditorias!.Add(auditorias);

            //calculo de ganancia de animales 
            if (entidad.VentaId != null && entidad.CompraId != null)
            {
                var compra = this.iConexion.Compras
                    .FirstOrDefault(x => x.Id == entidad.CompraId);

                var venta = this.iConexion.Ventas
                    .FirstOrDefault(x => x.Id == entidad.VentaId);

                if (compra != null && venta != null)
                {
                    decimal costoAnimal =
                        compra.PesoCompra * compra.PrecioKilo;

                    decimal valorVenta =
                        venta.PesoFinal * venta.PrecioKilo;

                    decimal ganancia =
                        valorVenta - costoAnimal;

                    decimal porcentajeGanancia = 0;

                    if (costoAnimal > 0)
                    {
                        porcentajeGanancia =
                            (ganancia / costoAnimal) * 100;
                    }

                    entidad.Ganancia = ganancia;
                    entidad.PorcentajeGanancia =
                        porcentajeGanancia;
                }
            }

            this.iConexion!.SaveChanges();

            // RECALCULAR LOTE ANTERIOR
            if (loteAnteriorId != null)
            {
                var loteAnterior = this.iConexion.Lotes
                    .FirstOrDefault(x => x.Id == loteAnteriorId);

                if (loteAnterior != null)
                {
                    loteAnterior.CantidadAnimales =
                        this.iConexion.Animales
                        .Count(x => x.LoteId == loteAnteriorId);

                    
                }
            }

            // RECALCULAR NUEVO LOTE
            if (entidad.LoteId != null)
            {
                var loteNuevo = this.iConexion.Lotes
                    .FirstOrDefault(x => x.Id == entidad.LoteId);

                if (loteNuevo != null)
                {
                    loteNuevo.CantidadAnimales =
                        this.iConexion.Animales
                        .Count(x => x.LoteId == entidad.LoteId);

                    
                }
            }

            this.iConexion.SaveChanges();




            return entidad;


        }

        public void Borrar(Animales entidad)
        {
            if (entidad.Id == 0)
            {
                throw new Exception("Id no válido");
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = ConfiguracionesC.obtener("string_conexion");

            var animal = this.iConexion.Animales.FirstOrDefault(e => e.Id == entidad.Id);

            if (animal == null)
                throw new Exception("No existe el registro en la base de datos ");

            int? loteId = animal.LoteId; //guardar lote antes de borrar



            this.iConexion.Animales.Remove(animal);



            Auditorias auditorias = new Auditorias();

            auditorias.Metodo = "Borrar";
            auditorias.Fecha = DateTime.Now;
            auditorias.Descripcion = "Se borró un Animal";
            this.iConexion.Auditorias!.Add(auditorias);

            this.iConexion.SaveChanges();

            // RECALCULAR EL LOTE
            if (loteId != null)
            {
                var lote = this.iConexion.Lotes
                    .FirstOrDefault(x => x.Id == loteId);

                if (lote != null)
                {
                    lote.CantidadAnimales =
                        this.iConexion.Animales
                        .Count(x => x.LoteId == loteId);

                    this.iConexion.Lotes!.Update(lote);
                    this.iConexion.SaveChanges();
                }
            }
        }

        public byte[] GenerarReporte(int Id)
        {
            ReporteAnimales reporte = new ReporteAnimales();
           

            return reporte.Generar(Id);
        }
    }
}
