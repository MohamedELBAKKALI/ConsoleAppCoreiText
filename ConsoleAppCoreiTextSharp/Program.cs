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

namespace ConsoleAppCoreiTextSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting Programe!");
            ITextManager textManager = new ITextManager();
            ////Testing Methode
            ///textManager.TestMethode("‪mypdf.pdf", "Center Header") ;
            /// Sign All pages 
            Console.WriteLine("shose a document to add a signature on all Pages!");
            string path = textManager.Initializepath("SignedDocAll12121");
            textManager.SignOnePagePath(path, "G455d4sdfsdf451sdf44554sd5f4545sd5dfdf45sd", 1,12,true) ;
            PdfDocument pdfdocument = textManager.Initialize("SignedDocAll12121");

            textManager.SignAllPages(pdfdocument,"G455d4sdfsdf451sdf44554sd5f4545sd5dfdf45sd",12,true);
            Console.WriteLine("Done Successfully!");
            /// Sign One page
            Console.WriteLine("shose a document to add a signature on one page Pages!");
            int pageNumber = 1;
            PdfDocument pdfdocumentone = textManager.Initialize("SignedDocOnePage21112");

            textManager.SignOnePage(pdfdocumentone, "G4444f4546sdf4fsd54f345sdf3454sdf4df4sdsd4", pageNumber, 12, true);
            Console.WriteLine("Done Successfully!");


            Console.WriteLine("Done Successfully!");
        }
    }
}
