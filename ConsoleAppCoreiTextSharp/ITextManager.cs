using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;


using iText.Kernel.Geom;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace ConsoleAppCoreiTextSharp
{
    class ITextManager
    {
        public void TestMethode(string path, string text)
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

            string pat = "‪‪mypdf.pdf";

            //PdfWriter writer = new PdfWriter(pat);

            string[] files = Directory.GetFiles(".");
            
            if (files.Length >0)
            {
                //pat = files.FirstOrDefault(f => f.Contains(pat));


                int i = 0;
                foreach (var item in files)
                {
                    
                    Console.WriteLine(i +":" +item);
                    i++;
                }

                Console.WriteLine(pat);
            }
            Console.WriteLine("Please Insert the index :");
            int index = int.Parse(Console.ReadLine());
            pat = files[index];
            //pat =  Path.Combine( Directory.GetCurrentDirectory(),pat);
            Console.WriteLine(pat);

            if (File.Exists(pat))
            {

                var pdfReader = new PdfReader(pat);

                PdfDocument pdf = new PdfDocument(pdfReader, new PdfWriter("‪v2.pdf"));


                Document document = new Document(pdf);
                Paragraph Par = new Paragraph("Name of user TESTPDF")
                   .SetTextAlignment(TextAlignment.RIGHT)
                   .SetFixedPosition(1,100,100,40)
                   .SetFontSize(20);

                // 1 is page number

                document.Add(Par);

                /*int llx = 50;
                int lly = 650;
                int urx = 400;
                int ury = 800;

                Rectangle rectangle = new Rectangle(llx, lly, urx - llx, ury - lly);
                PdfCanvas canvas = new PdfCanvas(pdf.AddNewPage());
                canvas.SetStrokeColor(ColorConstants.RED)
                    .SetLineWidth(0.5f)
                    .Rectangle(rectangle)
                    .Stroke();

                Paragraph p = new Paragraph("This text is displayed above the vertical middle of the red rectangle.");
                new Canvas(canvas, rectangle)
                    .Add(p.SetFixedPosition(llx, (ury + lly) / 2, urx - llx).SetMargin(0));*/

                document.Close();
            }
            else
            {
                Console.Write("PDF Not Found");
            }

            
            

        }
        public String Initializepath(string signedDocNewName)
        {
            string path = "testtest";
            try
            {
                string[] files = Directory.GetFiles(".");
                if (files.Length > 0)
                {
                    int i = 0;
                    foreach (var item in files)
                    {
                        Console.WriteLine(i + ":" + item);
                        i++;
                    }
                    Console.WriteLine(path);
                }
                Console.WriteLine("Please Insert the index :");
                int index = int.Parse(Console.ReadLine());
                path = files[index];
                if (File.Exists(path))
                {
                    var pdfReader = new PdfReader(path);
                    PdfDocument pdfDocument = new PdfDocument(pdfReader, new PdfWriter(signedDocNewName + ".pdf"));
                    Document document = new Document(pdfDocument);
                }
                else
                {
                    Console.Write("PDF Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return path;
        }
        PdfDocument pdfDocument;
        public PdfDocument Initialize(string signedDocNewName)
        {
            try
            {
                string path = "testtest";
                string[] files = Directory.GetFiles(".");
                if (files.Length > 0)
                {
                    int i = 0;
                    foreach (var item in files)
                    {
                        Console.WriteLine(i + ":" + item);
                        i++;
                    }
                    Console.WriteLine(path);
                }
                Console.WriteLine("Please Insert the index :");
                int index = int.Parse(Console.ReadLine());
                path = files[index];
                if (File.Exists(path))
                {
                    var pdfReader = new PdfReader(path);
                    PdfDocument pdfDocument = new PdfDocument(pdfReader, new PdfWriter(signedDocNewName+".pdf"));
                    Document document = new Document(pdfDocument);
                }
                else
                {
                    Console.Write("PDF Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pdfDocument;
        }

        public void Sign(Document document, string signature, int PageNumber, int FontSize, Boolean OnTop)
        {
            if (OnTop == true)
            {
                Paragraph Par = new Paragraph(signature)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFixedPosition(PageNumber, 10,810, 600)
               .SetFontSize(FontSize);
                document.Add(Par);
            }
            else
            {
                Paragraph Par = new Paragraph(signature)
               .SetTextAlignment(TextAlignment.RIGHT)
               .SetFixedPosition(PageNumber, 10, 10, 550)
               .SetFontSize(FontSize);
                document.Add(Par);
            }
        }
        public void SignOnePage(PdfDocument pdfdocument, string signature, int pageNumber,int FontSize,Boolean OnTop)
        {
            Document document = new Document(pdfdocument);
            Sign(document, signature, pageNumber, FontSize, OnTop);
            document.Close();
        }

        public void SignAllPages(PdfDocument pdfdocument, string signature, int FontSize, Boolean OnTop)
        {
            Document document = new Document(pdfdocument);
            int pages = pdfdocument.GetNumberOfPages();
            for (int i = 1; i<= pages; i++)
            {
                Sign(document, signature, i, FontSize, OnTop) ;
            }
            document.Close();
        }
        public void SignOnePagePath(string path, string signature, int pageNumber, int FontSize, Boolean OnTop)
        {
            var pdfReader = new PdfReader(path);
            PdfDocument pdfDocument = new PdfDocument(pdfReader, new PdfWriter("signedDocNewName2top.pdf"));
            Document document = new Document(pdfDocument);
            Sign(document, signature, pageNumber, FontSize, OnTop);
            document.Close();
        }
        public void SignAllPagesPath(string path, string signature, int FontSize, Boolean OnTop)
        {
            var pdfReader = new PdfReader(path);
            PdfDocument pdfDocument = new PdfDocument(pdfReader, new PdfWriter("signedallNewName2top.pdf"));
            Document document = new Document(pdfDocument);
            int pages = pdfDocument.GetNumberOfPages();
            for (int i = 1; i <= pages; i++)
            {
                Sign(document, signature, i, FontSize, OnTop);
            }
            document.Close();
        }

    }
}
