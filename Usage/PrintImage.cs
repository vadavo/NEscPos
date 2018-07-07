using ESCPOS.NET;
using ESCPOS.NET.Connectors;
using ESCPOS.NET.Printable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Usage
{
    class PrintImage
    {
        static void Main(string[] args)
        {
            IPrintConnector connector = new NetworkPrintConnector("10.0.0.50", 9100);
            IPrinter printer = new Printer(connector);

            var img = new Image(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"logo.png"));

            printer.Print(img);
        }
    }
}
