using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCDataManager.Controllers.Internals
{
    using System;
    using System.Collections.Specialized;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text;
    using System.Web;
    using Svg;
    using Svg.Transforms;
    using System.Xml;
    using System.Drawing;

    /// <summary>
    /// .NET chart exporting class for Highcharts JS JavaScript charts.
    /// </summary>
    internal class Exporter
    {
        /// <summary>
        /// Default file name to use for chart exports if not otherwise specified.
        /// </summary>
        private const string DefaultFileName = "Chart";

        /// <summary>
        /// PDF metadata Creator string.
        /// </summary>
        private const string PdfMetaCreator =
          "Tek4(TM) Exporting Module for Highcharts JS from Tek4.com";

        /// <summary>
        /// Gets the HTTP Content-Disposition header to be sent with an HTTP
        /// response that will cause the client's browser to open a file save
        /// dialog with the proper file name.
        /// </summary>
        public string ContentDisposition { get; private set; }

        /// <summary>
        /// Gets the MIME type of the exported output.
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// Gets the file name with extension to use for the exported chart.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the chart name (same as file name without extension).
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the SVG chart document (XML text).
        /// </summary>
        public string Svg { get; private set; }

        /// <summary>
        /// Gets the pixel width of the exported chart image.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Initializes a new chart Export object using the specified file name, 
        /// output type, chart width and SVG text data.
        /// </summary>
        /// <param name="fileName">The file name (without extension) to be used 
        /// for the exported chart.</param>
        /// <param name="type">The requested MIME type to be generated. Can be
        /// 'image/jpeg', 'image/png', 'application/pdf' or 'image/svg+xml'.</param>
        /// <param name="width">The pixel width of the exported chart image.</param>
        /// <param name="svg">An SVG chart document to export (XML text).</param>
        internal Exporter(
          string fileName,
          string type,
          int width,
          string svg)
        {
            string extension;

            this.ContentType = type.ToLower();
            this.Name = fileName;
            this.Svg = svg;
            this.Width = width;

            // Validate requested MIME type.
            switch (ContentType)
            {
                case "image/jpeg":
                    extension = "jpg";
                    break;

                case "image/png":
                    extension = "png";
                    break;

                case "application/pdf":
                    extension = "pdf";
                    break;

                case "image/svg+xml":
                    extension = "svg";
                    break;

                // Unknown type specified. Throw exception.
                default:
                    throw new ArgumentException(
                      string.Format("Invalid type specified: '{0}'.", type));
            }

            // Determine output file name.
            this.FileName = string.Format(
              "{0}.{1}",
              string.IsNullOrEmpty(fileName) ? DefaultFileName : fileName,
              extension);

            // Create HTTP Content-Disposition header.
            this.ContentDisposition =
              string.Format("attachment; filename={0}", this.FileName);
        }

        /// <summary>
        /// Creates an SvgDocument from the SVG text string.
        /// </summary>
        /// <returns>An SvgDocument object.</returns>
        private SvgDocument CreateSvgDocument()
        {
            SvgDocument svgDoc;

            // Create a MemoryStream from SVG string.
            using (MemoryStream streamSvg = new MemoryStream(
              Encoding.UTF8.GetBytes(this.Svg)))
            {
                svgDoc = SvgDocument.Open<SvgDocument>(streamSvg);
            }

            // Scale SVG document to requested width.
            svgDoc.Transforms = new SvgTransformCollection();
            float scalar = (float)this.Width / (float)svgDoc.Width;
            svgDoc.Transforms.Add(new SvgScale(scalar, scalar));
            svgDoc.Width = new SvgUnit(svgDoc.Width.Type, svgDoc.Width * scalar);
            svgDoc.Height = new SvgUnit(svgDoc.Height.Type, svgDoc.Height * scalar);

            return svgDoc;
        }

        /// <summary>
        /// Exports the chart to the specified output stream as binary. When 
        /// exporting to a web response the WriteToHttpResponse() method is likely
        /// preferred.
        /// </summary>
        /// <param name="outputStream">An output stream.</param>
        internal void WriteToStream(Stream outputStream)
        {
            switch (this.ContentType)
            {
                case "image/jpeg":
                    CreateSvgDocument().Draw().Save(
                      outputStream,
                      ImageFormat.Jpeg);
                    break;

                case "image/png":
                    // PNG output requires a seekable stream.
                    using (MemoryStream seekableStream = new MemoryStream())
                    {
                        CreateSvgDocument().Draw().Save(
                            seekableStream,
                            ImageFormat.Png);
                        seekableStream.WriteTo(outputStream);
                    }
                    break;

                //case "application/pdf":
                //    SvgDocument svgDoc = CreateSvgDocument();
                //    Bitmap bmp = svgDoc.Draw();

                //    pdfDocument doc = new pdfDocument(this.Name, null);
                //    pdfPage page = doc.addPage(bmp.Height, bmp.Width);
                //    page.addImage(bmp, 0, 0);
                //    doc.createPDF(outputStream);
                //    break;

                //case "image/svg+xml":
                //    using (StreamWriter writer = new StreamWriter(outputStream))
                //    {
                //        writer.Write(this.Svg);
                //        writer.Flush();
                //    }

                //    break;

                default:
                    throw new InvalidOperationException(string.Format(
                      "ContentType '{0}' is invalid.", this.ContentType));
            }

            outputStream.Flush();
        }

        internal string WriteToFile(string workPath)
        {
            var fileName = Path.Combine(workPath, FileName);
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    WriteToStream(fs);
                }
                return FileName;
            }
            catch(IOException ex)
            {
                throw ex;
            }
             
        }
    }
}
