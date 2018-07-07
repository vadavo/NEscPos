using ESCPOS.NET;
using ESCPOS.NET.Connectors;
using System;

namespace Usage
{
    class PrintString
    {
        static void Main(string[] args)
        {
            IPrintConnector connector = new NetworkPrintConnector("10.0.0.50", 9100);
            IPrinter printer = new Printer(connector);

            printer.Print("Hello Word 1");
            printer.Print("Hello Word 2");
            printer.Print("Hello Word 3");
            printer.Print("Hello Word 4");
            printer.Cut();

            Console.ReadKey();
        }
    }
}
