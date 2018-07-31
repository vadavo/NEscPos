using ESCPOS.NET;
using ESCPOS.NET.Connectors;
using ESCPOS.NET.Printable;
using System;

namespace Usage
{
    class PrintImage
    {
        static void Main()
        {
            IPrintConnector connector = new NetworkPrintConnector("10.0.0.50", 9100);
            IPrinter printer = new Printer(connector);

            printer.Reset();

            var image = new Image();

            printer.Print(image);
            printer.Feed();
            printer.Feed();
            printer.Cut();
            printer.Reset();

            Console.ReadKey();
        }
    }
}
