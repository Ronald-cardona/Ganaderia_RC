using aplicacion_libreria.entidades;
using aplicacion_libreria.implementaciones;
using aplicacion_libreria.nucleo;
using iText.IO.Image;
using iText.Kernel.Pdf;

using iText.Layout.Element;
using ScottPlot;

using Document = iText.Layout.Document;
using Image = iText.Layout.Element.Image;



namespace aplicacion_libreria.reportes
{
    public  class ReporteHistorialPesos
    {
        public  byte[] Generar(int IdAnimal)
        {

            Conexion conexion = new Conexion();

            conexion.string_conexion = ConfiguracionesC.obtener("string_conexion");



            var animal = conexion.Animales!
                .First(x => x.Id == IdAnimal);

            var historial = conexion.HistorialPesos!
                .Where(x => x.IdAnimal == IdAnimal)
                .OrderBy(x => x.FechaPesajeActual)
                .ToList();

            List<double> pesos = new();
            List<double> dias = new();

            int contador = 0;

            pesos.Add((double)animal.PesoInicial);
            dias.Add(contador);


            foreach (var item in historial)
            {
                contador++;

                pesos.Add((double)item.PesoActual);
                dias.Add(contador);
            }

            var plot = new Plot();

            plot.Add.Scatter(
                dias.ToArray(),
                pesos.ToArray());

            plot.Title(
                $"Historial de peso animal {animal.Codigo}");

            plot.XLabel("Pesajes");

            plot.YLabel("Peso Kg");

            string rutaGrafica = Path.Combine(Path.GetTempPath(), "graficaPeso.png");
         


            plot.SavePng(rutaGrafica, 800, 400);


            using var memoryStream = new MemoryStream();
            

            PdfWriter writer = new PdfWriter(memoryStream);
            

            PdfDocument pdf = new PdfDocument(writer);
            

            Document document = new Document(pdf);

            document.Add(new Paragraph("REPORTE HISTORIAL DE PESOS"));
          

            document.Add(new Paragraph($"Animal: {animal.Codigo}"));
          

            document.Add(new Paragraph($"Fecha reporte: {DateTime.Now}"));


            ImageData image = ImageDataFactory.Create(rutaGrafica);
            

            Image imagenGrafica = new Image(image);

          

            document.Add(imagenGrafica);


            Table tabla = new Table(4);
            

            tabla.AddHeaderCell("Fecha");
           

            tabla.AddHeaderCell("Peso");
           

            tabla.AddHeaderCell("Ganancia");
            

            tabla.AddHeaderCell("Ganancia diaria");

            foreach (var item in historial)
            {
                tabla.AddCell(item.FechaPesajeActual.ToShortDateString());
                

                tabla.AddCell(item.PesoActual.ToString("N2"));
               

                tabla.AddCell(item.GananciaPeso?.ToString("N2"));
               

                tabla.AddCell(item.GananciaDiaria?.ToString("N2"));

                

               
            }

            document.Add(tabla);
            document.Close();
            return memoryStream.ToArray();
        }




    }
}
