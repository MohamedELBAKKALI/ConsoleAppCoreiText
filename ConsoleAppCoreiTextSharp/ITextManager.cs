using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ConsoleAppCoreiTextSharp
{
    class ITextManager
    {
        public void Write(string path, string text)
        {
            // Must have write permissions to the path folder 
           /* string pat = "‪oncf_voyages.pdf";
            PdfWriter writer = new PdfWriter(pat);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph(text)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            document.Add(header);

            document.Close();*/




            string pat = @"‪‪C:\Users\Hp ProBook\source\repos\ConsoleAppCoreiTextSharp\ConsoleAppCoreiTextSharp\bin\Debug\netcoreapp3.1\ADD1-TD2.pdf";


            //PdfWriter writer = new PdfWriter(pat);


            if (File.Exists(pat))
            {

                var pdfReader = new PdfReader(pat);

                PdfDocument pdf = new PdfDocument(pdfReader, new PdfWriter("‪oncf_voyagesv2.pdf"));


                Document document = new Document(pdf);
                Paragraph header = new Paragraph(text)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(20);

                document.Add(header);

                document.Close();
            }
            else
            {
                Console.Write("PDF Not Found");
            }
            

        }
            
        }
}
