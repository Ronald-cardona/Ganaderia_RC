using aplicacion_libreria.implementaciones;
using aplicacion_libreria.nucleo;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Microsoft.EntityFrameworkCore;
using ScottPlot;
using Document = iText.Layout.Document;
using Image = iText.Layout.Element.Image;

namespace aplicacion_libreria.reportes
{
    public class ReporteAnimales
    {
        public byte[] Generar(int Id)
        {
            Conexion conexion = new Conexion();

            conexion.string_conexion = ConfiguracionesC.obtener("string_conexion");
           

            var animal = conexion.Animales!.Include(x => x._compra).Include(x => x._venta).First(x => x.Id == Id);
                

            var compra = animal._compra;
            var venta = animal._venta;

            if (compra == null)
                throw new Exception("El animal no tiene compra asociada");
            

            if (venta == null)
                throw new Exception("El animal no tiene venta asociada");
            

            decimal compraTotal = compra.PesoCompra * compra.PrecioKilo;
           

            decimal ventaTotal = venta.PesoFinal * venta.PrecioKilo;
           

            decimal ganancia = ventaTotal - compraTotal;
            

            decimal porcentajeGanancia = compraTotal == 0 ? 0 : (ganancia / compraTotal) * 100;


            //parte de la grafica 

            double[] valores =
           {
                (double)compraTotal,
                (double)ventaTotal,
                (double)ganancia
            };

            string[] etiquetas =
          {
                "Compra",
                "Venta",
                "Ganancia"
            };


            var plot = new Plot();

            plot.Add.Bars(valores);

            plot.Title($"Rentabilidad Animal {animal.Codigo}");
          

            plot.YLabel("Valor en dinero");

            plot.Axes.Bottom.TickGenerator =
                new ScottPlot.TickGenerators.NumericManual(
                    new double[] { 0, 1, 2 },
                    etiquetas);

            string rutaGrafica =
                Path.Combine(
                    Path.GetTempPath(),
                    "rentabilidadAnimal.png");

            plot.SavePng(rutaGrafica, 800, 400);

            //parte del pdf 

            using var memoryStream = new MemoryStream();
           

            PdfWriter writer = new PdfWriter(memoryStream);
           

            PdfDocument pdf = new PdfDocument(writer);
            

            Document document = new Document(pdf);
           

            document.Add(new Paragraph("REPORTE DE RENTABILIDAD DEL ANIMAL"));
           

            document.Add(new Paragraph($"Animal: {animal.Codigo}"));
          

            document.Add(new Paragraph($"Fecha reporte: {DateTime.Now:dd/MM/yyyy}"));
           

            document.Add(new Paragraph($"Peso inicial: {animal.PesoInicial:N2} kg"));
           

            document.Add(new Paragraph($"Peso final: {venta.PesoFinal:N2} kg"));
           

            Table tabla = new Table(2);
            

            tabla.AddHeaderCell("Concepto");
            tabla.AddHeaderCell("Valor");

            tabla.AddCell("Costo compra");
            tabla.AddCell($"${compraTotal:N2}");
           

            tabla.AddCell("Ingreso venta");
            tabla.AddCell($"${ventaTotal:N2}");
          

            tabla.AddCell("Ganancia dinero");
            tabla.AddCell($"${ganancia:N2}");
           

            tabla.AddCell("Ganancia %");
            tabla.AddCell($"{porcentajeGanancia:N2}%");


            document.Add(tabla);

            ImageData image =
                ImageDataFactory.Create(
                    rutaGrafica);

            Image imagen = new Image(image);
          

            document.Add(imagen);

            document.Add(
                new Paragraph(
                    $"El animal generó una rentabilidad de " +
                    $"{porcentajeGanancia:N2}% " +
                    $"equivalente a ${ganancia:N2}."));

            document.Close();

            return memoryStream.ToArray();



        }
    }
}
