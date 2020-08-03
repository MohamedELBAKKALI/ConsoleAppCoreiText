using System;

namespace ConsoleAppCoreiTextSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ITextManager textManager = new ITextManager();
            textManager.Write("‪mypdf.pdf", "Center Header") ;

            Console.WriteLine("Done!");
        }
    }
}
