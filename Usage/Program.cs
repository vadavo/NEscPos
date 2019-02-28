using System;
using Vadavo.NEscPos;
using Vadavo.NEscPos.Connectors;

namespace Usage
{
    class Program
    {
        static void Main()
        {
            using (IPrintConnector networkConnector = new NetworkPrintConnector("10.0.0.50", 9100))
            using (IPrinter printer = new Printer(networkConnector))
            {
                printer.Reset();
                printer.Print("Hello from VADAVO NEscPos");
                printer.Cut();
            }

            Console.WriteLine("A hello message has been printed. Press any key.");
            Console.ReadKey();
        }
    }
}
