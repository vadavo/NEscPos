using ESCPOS.NET;
using ESCPOS.NET.Connectors;
using System;

namespace Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrintConnector connector = new NetworkPrintConnector("10.0.0.50", 9100);
            IPrinter printer = new Printer(connector);

            printer.Print("Hola");
            printer.Cut();
        }
    }
}
