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

            printer.Print(new Justification(JustificationType.Center));
            printer.Print(new Font(FontMode.Emphasized));
            printer.Print("VADAVO");
            printer.Feed();
            printer.Feed();
            printer.Print("Tienda VADAVO Quart");
            printer.Print(new Font());
            printer.Print("C. Quart 112 Bajo. 46008 Valencia");
            printer.Print("960262326 - tienda.quart@vadavo.com");
            printer.Feed();

            printer.Reset();
            
            printer.Print(new Justification(JustificationType.Center));
            printer.Print(new Font(FontMode.DoubleHeight, FontMode.Emphasized));
            printer.Print("Ticket Nº 2018000001 - Fecha: 11/08/2018");
            printer.Feed();
            printer.Feed();
            printer.Reset();

            printer.Print("Cristal Templado iPhone X");
            printer.Feed();
            
            printer.Print("iPhone X");
            printer.Reset();
            printer.Print(new Font(FontMode.FontB));
            printer.Print("    S/N: AP-88662-232-21");
            printer.Reset();
            printer.Feed();
            printer.Feed();


            printer.Print(new Barcode("2018000001"));
            printer.Print(new Justification(JustificationType.Center));
            printer.Print("VADAVO SOLUCIONES S.L.");
            printer.Print(new Font(FontMode.FontB));
            printer.Print("CIF: B98455071");
            printer.Cut();

            Console.ReadKey();
           
        }
    }
}
