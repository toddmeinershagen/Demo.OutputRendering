using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.text.pdf;

namespace Demo.OutputRendering.CommandUI
{
    public class PdfRenderer
    {
        public bool Render(Context context)
        {
            var filePath = string.Format("{0}.pdf", context.TemplateId);

            using (var output = File.OpenWrite(Path.Combine(Environment.CurrentDirectory, filePath)))
            {
                using (var document = new Document(PageSize.A4, 50, 50, 25, 25))
                {
                    var writer = PdfWriter.GetInstance(document, output);
                    document.Open();

                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(context.Content));
                }
            }

            return true;
        }
    }
}