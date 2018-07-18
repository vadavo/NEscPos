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

            printer.Print("Empieza código de barras");
            printer.Print(new Barcode("Hola"));
            printer.Print("Termina código de barras");
            printer.Cut();

            Console.ReadKey();
           
        }
    }
}
