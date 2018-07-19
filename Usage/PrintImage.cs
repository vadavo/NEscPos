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
            printer.Print(new Bytes(new byte[]
            {
                0x1C, 0x71, 0x1, 0x75, 0, 0x44
            }));
            printer.Feed();
            printer.Feed();
            
            printer.Cut();
            printer.Reset();

            Console.ReadKey();
           
        }
    }
}
